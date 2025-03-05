import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OrientacionSexual } from 'src/app/interfaces/orientacion-sexual';
import { DecodedService } from 'src/app/services/decoded.service';
import { OrientacionSexualService } from 'src/app/services/orientacion-sexual.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-orientacion',
  templateUrl: './add-edit-orientacion.component.html',
  styleUrls: ['./add-edit-orientacion.component.css']
})
export class AddEditOrientacionComponent implements OnInit {
  public get OrientacionService(): OrientacionSexualService {
    return this._OrientacionService;
  }
  public set OrientacionService(value: OrientacionSexualService) {
    this._OrientacionService = value;
  }
  form:any;
  id!:number;
  operacion:string="Agregar ";

  constructor(
    private fb:FormBuilder,
    private _OrientacionService: OrientacionSexualService,
    private router:Router,
    private ruta:ActivatedRoute,
    private decode:DecodedService
    
  ){
    this.form=fb.group({
      orientacion:['',[Validators.required]]
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
      console.log('this.id: ', this.id);
    })

  }

  agregarOrientacion(){

    const lista:OrientacionSexual={
      orientacion:this.form.value.orientacion,
      idUsuarioCreo:this.decode.decodedTokenIdUsuario(),
      idUsuarioModifico:this.decode.decodedTokenIdUsuario()
    }
    if(this.id==0){
      this._OrientacionService.postOrientacion(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregada exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/orientacion_sexual']);
      });

    }else{
      this._OrientacionService.putOrientacion(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Registro Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/mantenimientos/orientacion_sexual']);
      });
    }
  }

  volver(){
    this.router.navigate(['home/mantenimientos/orientacion_sexual'])
  }

  getFiltroOrientacion(id:number){
    this._OrientacionService.getFiltroOrientacion(id).subscribe(res=>{
      this.form.patchValue({
        orientacion:res.lista.orientacion
      });
    });

  }

  ngOnInit(): void {
    if(this.id!=0){
      this.operacion="Editar ";
      this.getFiltroOrientacion(this.id);

    }

  }
}
