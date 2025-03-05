import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CondicionMigratoria } from 'src/app/interfaces/condicion-migratoria';
import { CondicionMigratoriaService } from 'src/app/services/condicion-migratoria.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-condicion-migratoria',
  templateUrl: './add-edit-condicion-migratoria.component.html',
  styleUrls: ['./add-edit-condicion-migratoria.component.css']
})
export class AddEditCondicionMigratoriaComponent {

  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _condicionMigrService: CondicionMigratoriaService,
    private router:Router,
    private ruta:ActivatedRoute

  ){
    this.form=fb.group({
      condicion:['',[Validators.required]]
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
      console.log('this.id: ', this.id);
    })

  }

  agregarCondicionMig(){
    const lista:CondicionMigratoria={
      nombreCondicion:this.form.value.condicion,

    }
    if(this.id==0){
      this._condicionMigrService.postCondicionMigratoria(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregada exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/condicion_migratoria']);
      });

    }else{
      this._condicionMigrService.putCondicionMigratoria(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Registro Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/condicion_migratoria']);
      });
    }
  }

  volver(){
    this.router.navigate(['home/mantenimientos/condicion_migratoria'])
  }

  getFiltroCondicionMig(id:number){
    this._condicionMigrService.getFiltroCondicionMigratoria(id).subscribe(res=>{
      this.form.patchValue({
        condicion:res.lista.nombreCondicion
      });
    });

  }

  ngOnInit(): void {
    if(this.id!=0){
      this.operacion="Editar ";
      this.getFiltroCondicionMig(this.id);

    }

  }

}
