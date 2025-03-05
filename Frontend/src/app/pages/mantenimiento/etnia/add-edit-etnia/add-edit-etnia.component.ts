import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Etnia } from 'src/app/interfaces/etnia';
import { EtniaService } from 'src/app/services/etnia.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-etnia',
  templateUrl: './add-edit-etnia.component.html',
  styleUrls: ['./add-edit-etnia.component.css']
})
export class AddEditEtniaComponent implements OnInit {
  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _etniaService: EtniaService,
    private router:Router,
    private ruta:ActivatedRoute

  ){
    this.form=fb.group({
      etnia:['',[Validators.required]]
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
      console.log('this.id: ', this.id);
    })

  }

  agregarEtnia(){
    const lista:Etnia={
      nombreEtnia:this.form.value.etnia,

    }
    if(this.id==0){
      this._etniaService.postEtnia(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregada exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/etnias']);
      });

    }else{
      this._etniaService.putEtnia(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Registro Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/etnias']);
      });
    }
  }

  volver(){
    this.router.navigate(['home/mantenimientos/etnias'])
  }

  getFiltroEtnia(id:number){
    this._etniaService.getFiltroEtnia(id).subscribe(res=>{
      this.form.patchValue({
        etnia:res.lista.nombreEtnia
      });
    });

  }

  ngOnInit(): void {
    if(this.id!=0){
      this.operacion="Editar ";
      this.getFiltroEtnia(this.id);

    }

  }
}
