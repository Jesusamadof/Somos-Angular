import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Modalidad } from 'src/app/interfaces/modalidad';
import { DecodedService } from 'src/app/services/decoded.service';
import { ModalidadService } from 'src/app/services/modalidad.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-modalidad',
  templateUrl: './add-edit-modalidad.component.html',
  styleUrls: ['./add-edit-modalidad.component.css']
})
export class AddEditModalidadComponent implements OnInit {
  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _modalidadService:ModalidadService,
    private router:Router,
    private ruta:ActivatedRoute,
    private _decodedService:DecodedService

  ){
    this.form=fb.group({
      modalidad:['',[Validators.required]],
    
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

  }

  addEdit(){
    const lista:Modalidad={
      modalidad:this.form.value.modalidad,
      idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
      idUsuarioModifico:this._decodedService.decodedTokenIdUsuario(),

    }
    if(this.id==0){
      this._modalidadService.postModalidad(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/modalidades']);
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
      this._modalidadService.putModalidad(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Registro Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/modalidades']);
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
    this.router.navigate(['home/mantenimientos/modalidades'])
  }

  getFiltroModalidad(id:number){
    this._modalidadService.getFiltroModalidad(id).subscribe(res=>{
      this.form.patchValue({
        modalidad:res.lista.modalidad,
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
      this.getFiltroModalidad(this.id);

    }

  }

}
