import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoRelacion } from 'src/app/interfaces/tipo-relacion';
import { DecodedService } from 'src/app/services/decoded.service';
import { TipoRelacionService } from 'src/app/services/tipo-relacion.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-tipo-relacion',
  templateUrl: './add-edit-tipo-relacion.component.html',
  styleUrls: ['./add-edit-tipo-relacion.component.css']
})
export class AddEditTipoRelacionComponent {
  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _tipoRelacionservice:TipoRelacionService,
    private router:Router,
    private ruta:ActivatedRoute,
    private _decodedService:DecodedService

  ){
    this.form=fb.group({
      tipoRelacion:['',[Validators.required]],
    
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

  }

  addEdit(){
    const lista:TipoRelacion={
      tipoRelacion:this.form.value.tipoRelacion,
      idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
      idUsuarioModifico:this._decodedService.decodedTokenIdUsuario(),

    }
    if(this.id==0){
      this._tipoRelacionservice.postTipoRelacion(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/tiporelacion']);
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
      this._tipoRelacionservice.putTipoRelacion(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Registro Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/tiporelacion']);
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
    this.router.navigate(['home/mantenimientos/tiporelacion'])
  }

  getFiltroTipoRelacion(id:number){
    this._tipoRelacionservice.getFiltroTipoRelacion(id).subscribe(res=>{
      this.form.patchValue({
        tipoRelacion:res.lista.tipoRelacion,
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
      this.getFiltroTipoRelacion(this.id);

    }

  }
}
