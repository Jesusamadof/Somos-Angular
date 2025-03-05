import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoVictima } from 'src/app/interfaces/tipo-victima';
import { DecodedService } from 'src/app/services/decoded.service';
import { TipoVictimaService } from 'src/app/services/tipo-victima.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-tipo-victima',
  templateUrl: './add-edit-tipo-victima.component.html',
  styleUrls: ['./add-edit-tipo-victima.component.css']
})
export class AddEditTipoVictimaComponent {
  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _tipovictima:TipoVictimaService,
    private router:Router,
    private ruta:ActivatedRoute,
    private _decodedService:DecodedService

  ){
    this.form=fb.group({
      tipoVictima:['',[Validators.required]],
    
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

  }

  addEdit(){
    const lista:TipoVictima={
      tipoVictima:this.form.value.tipoVictima,
      idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
      idUsuarioModifico:this._decodedService.decodedTokenIdUsuario(),

    }
    if(this.id==0){
      this._tipovictima.postTipoVictima(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/tipovictima']);
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
      this._tipovictima.putTipoVictima(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Registro Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/tipovictima']);
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
    this.router.navigate(['home/mantenimientos/tipovictima'])
  }

  getFiltroModalidad(id:number){
    this._tipovictima.getFiltroTipoVictima(id).subscribe(res=>{
      this.form.patchValue({
        tipoVictima:res.lista.tipoVictima,
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
