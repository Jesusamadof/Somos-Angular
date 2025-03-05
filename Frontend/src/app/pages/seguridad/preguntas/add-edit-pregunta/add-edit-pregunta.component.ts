import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Pregunta } from 'src/app/interfaces/pregunta';
import { PreguntasService } from 'src/app/services/preguntas.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-pregunta',
  templateUrl: './add-edit-pregunta.component.html',
  styleUrls: ['./add-edit-pregunta.component.css']
})
export class AddEditPreguntaComponent implements OnInit {

  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _PreguntaService:PreguntasService,
    private router:Router,
    private ruta:ActivatedRoute

  ){
    this.form=fb.group({
      pregunta:['',[Validators.required]],
      descripcion:['',Validators.required],
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

  }

  agregarPregunta(){
    const lista:Pregunta={
      pregunta:this.form.value.pregunta,
      descripcion:this.form.value.descripcion
    }
    if(this.id==0){
      this._PreguntaService.postPregunta(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Pregunta agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/preguntas']);
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
      this._PreguntaService.putPregunta(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Pregunta Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/preguntas']);
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
    this.router.navigate(['home/seguridad/preguntas'])
  }

  getFiltroPregunta(id:number){
    this._PreguntaService.getFiltroPregunta(id).subscribe(res=>{
      this.form.patchValue({
        pregunta:res.lista.pregunta,
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
      this.getFiltroPregunta(this.id);

    }

  }

}
