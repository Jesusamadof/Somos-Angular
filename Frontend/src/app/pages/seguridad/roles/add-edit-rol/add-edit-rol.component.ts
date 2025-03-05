import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Rol } from 'src/app/interfaces/rol';
import { RolesService } from 'src/app/services/roles.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-rol',
  templateUrl: './add-edit-rol.component.html',
  styleUrls: ['./add-edit-rol.component.css']
})
export class AddEditRolComponent implements OnInit {
  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _rolService:RolesService,
    private router:Router,
    private ruta:ActivatedRoute

  ){
    this.form=fb.group({
      nombreRol:['',[Validators.required]],
      descripcion:['',Validators.required],
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

  }

  agregarRol(){
    const lista:Rol={
      nombreRol:this.form.value.nombreRol,
      descripcion:this.form.value.descripcion
    }
    if(this.id==0){
      this._rolService.postRol(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Rol agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/roles']);
      }, err=>{
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
      this._rolService.putRol(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Rol Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/roles']);
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
    this.router.navigate(['home/seguridad/roles'])
  }

  getFiltroRol(id:number){
    this._rolService.getFiltroRol(id).subscribe(res=>{
      this.form.patchValue({
        nombreRol:res.lista.nombreRol,
        descripcion:res.lista.descripcion
      });
    },
    err=>{
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
      this.getFiltroRol(this.id);

    }

  }

}
