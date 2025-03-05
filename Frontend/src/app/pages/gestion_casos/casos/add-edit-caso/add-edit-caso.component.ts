import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Caso } from 'src/app/interfaces/caso';
import { CasosService } from 'src/app/services/casos.service';
import { DecodedService } from 'src/app/services/decoded.service';
import { OrientacionSexualService } from 'src/app/services/orientacion-sexual.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-caso',
  templateUrl: './add-edit-caso.component.html',
  styleUrls: ['./add-edit-caso.component.css']
})
export class AddEditCasoComponent implements OnInit {

  form:FormGroup;
  id:any;
  operacion:string="Agregar ";
  orientaciones:any;



  constructor(
    private fb:FormBuilder,
    private _casosServices:CasosService,
    private _decodedService:DecodedService,
    private router:Router,
    private ruta:ActivatedRoute,
    private _orientacionService:OrientacionSexualService
  ){
this.form=fb.group({
  fecha:['',[Validators.required]],
  hora:['',[Validators.required]],
  lugar:['',[Validators.required]],
  nombreGenero:['',[Validators.required]],
  alias:['',[Validators.required]],
  dni:['',[Validators.required]],
  idOrientacion:['',[Validators.required]],
  otroNombre:['',[Validators.required]]
});

this.ruta.params.subscribe(param => {
  this.id = param['id'];
})
  }


  volver(){

  }


  addEdit(){

    const lista:Caso={
      fecha:this.form.value.fecha,
      hora:this.form.value.hora,
      lugar:this.form.value.lugar,
      nombreGenero:this.form.value.nombreGenero,
      alias:this.form.value.alias,
      dni:this.form.value.dni,
      idOrientacion:this.form.value.idOrientacion,
      otroNombre:this.form.value.otroNombre,
      idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
      idUsuarioModifico:this._decodedService.decodedTokenIdUsuario()
    };

    console.log('lista: ', lista);

    if(this.id=='0'){
      this._casosServices.postCaso(lista).subscribe((res:any)=>{
        if(res.ok){
          Swal.fire({
            title: "Agregado!",
            text: "Registro agregado exitosamente !!",
            icon: "success"
          });

          this.router.navigate(['home/casos/lista_casos']);

        }

      }, err=>{
        console.log('err:kkkkk ', err);
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
      this._casosServices.putCaso(this.id,lista).subscribe((res:any)=>{
        if(res.ok){
          Swal.fire({
            title: "Actualizado!",
            text: "Registro  Actualizado exitosamente !! ",
            icon: "success"
          });

          this.router.navigate(['home/casos/lista_casos']);

        }

      },err=>{
        console.log('err:jsjd ', err);
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
getOrientacion(){
  this._orientacionService.getOrientacion().subscribe(res=>{
    this.orientaciones=res.lista;
  });
}

  getFiltroCaso(id:number){
    this._casosServices.getFiltroCaso(id).subscribe(res=>{

      this.form.patchValue({
        fecha:res.lista.fecha,
        hora:res.lista.hora,
        lugar:res.lista.lugar,
        nombreGenero:res.lista.nombreGenero,
        alias:res.lista.alias,
        dni:res.lista.dni,
        idOrientacion:res.lista.idOrientacion,
        otroNombre:res.lista.otroNombre
      });


    });
  }





  ngOnInit(): void {
    this.getOrientacion();
    if(this.id!=0){
      this.getFiltroCaso(this.id);
    }

  }
}
