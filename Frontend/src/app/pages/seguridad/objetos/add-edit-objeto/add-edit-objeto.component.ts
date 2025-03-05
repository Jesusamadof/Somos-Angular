import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Objeto } from 'src/app/interfaces/objeto';
import { ObjetosService } from 'src/app/services/objetos.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-objeto',
  templateUrl: './add-edit-objeto.component.html',
  styleUrls: ['./add-edit-objeto.component.css']
})
export class AddEditObjetoComponent implements OnInit {

  form:FormGroup;
  id!:number;
  objetoPadre:any;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _objetoService:ObjetosService,
    private ruta:ActivatedRoute,
    private router:Router
  ){

    this.form=fb.group({
      idObjetoPadre:['',[Validators.required]],
      nombre:['',[Validators.required]],
      ruta:['',[Validators.required]],
      icono:['',[Validators.required]],
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
      console.log('this.id: ', this.id);
    })


  }


  agregarRol(){
    const lista:Objeto={
      idObjetoPadre:this.form.value.idObjetoPadre,
      nombreObjeto:this.form.value.nombre,
      ruta:this.form.value.ruta,
      icono:this.form.value.icono

    }
    if(this.id==0){
      this._objetoService.postObjeto(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Objeto agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/objetos']);
      },err=>{
        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          width:500,
          timer: 7000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
          }
        })

        Toast.fire({
          icon: 'error',
          title: `Error de Servidor. Intente nuevamente!!`
        });
      });

    }else{
      this._objetoService.putObjeto(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Objeto Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/objetos']);
      },err=>{
        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          width:500,
          timer: 7000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
          }
        })

        Toast.fire({
          icon: 'error',
          title: `Error de Servidor. Intente nuevamente!!`
        });
      });
    }
  }

  volver(){
    this.router.navigate(['home/seguridad/objetos'])
  }

  getFiltroObjeto(id:number){
    this._objetoService.getFiltroObjeto(id).subscribe(res=>{
      this.form.patchValue({
        idObjetoPadre:res.lista.idObjetoPadre,
        nombre:res.lista.nombreObjeto,
        ruta:res.lista.ruta,
        icono:res.lista.icono
      });
    },err=>{
      const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        width:500,
        timer: 7000,
        timerProgressBar: true,
        didOpen: (toast) => {
          toast.addEventListener('mouseenter', Swal.stopTimer)
          toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
      })

      Toast.fire({
        icon: 'error',
        title: `Error de Servidor. Intente nuevamente!!`
      });
    });
  }

  getFiltroObjetoPadre(){
    this._objetoService.getObjeto().subscribe(res=>{
    this.objetoPadre=res.lista.filter((x:any)=>x.idObjetoPadre==1);
    },err=>{
      const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        width:500,
        timer: 7000,
        timerProgressBar: true,
        didOpen: (toast) => {
          toast.addEventListener('mouseenter', Swal.stopTimer)
          toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
      })

      Toast.fire({
        icon: 'error',
        title: `Error de Servidor. Intente nuevamente!!`
      });
    });
  }

  ngOnInit(): void {
    if(this.id!=0){
      this.operacion="Editar ";
      this.getFiltroObjeto(this.id);
    }
this.getFiltroObjetoPadre();
  }
}
