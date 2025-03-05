import { MuniDeptService } from './../../../../services/muni-dept.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NivelEducativo } from 'src/app/interfaces/nivel-educativo';
import { Persona } from 'src/app/interfaces/persona';
import { DecodedService } from 'src/app/services/decoded.service';
import { NivelEducativoService } from 'src/app/services/nivel-educativo.service';
import { PersonasService } from 'src/app/services/personas.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-victima',
  templateUrl: './add-edit-victima.component.html',
  styleUrls: ['./add-edit-victima.component.css']
})
export class AddEditVictimaComponent implements OnInit {

  form:FormGroup;
  id!:number;
  operacion:string="Agregar ";
  departamentos:any;
  municipiosNac:any;
  municipiosDom:any;
  nivelesEducativos:any;
  estadoCivil:any[]=[
    {estado:'Soltero/a'},
    {estado:'Casado/a'},
    {estado:'Unión libre o unión de hecho'},
    {estado:'Separado/a'},
    {estado:'Divorciado/a'},
    {estado:'Viudo/a'}
  ];


  constructor(
    private fb:FormBuilder,
    private _muni_deptService:MuniDeptService,
    private _decodedService:DecodedService,
    private _personaService : PersonasService,
    private _nivelEducService:NivelEducativoService,
    private router:Router,
    private ruta:ActivatedRoute,
  ){
this.form=fb.group({
  dni:['',[Validators.required]],
  nombreLegal:['',[Validators.required]],
  fechaNacimiento:['',[Validators.required]],
  idNivelEduc:['',[Validators.required]],
  nacionalidad:['',[Validators.required]],
  telefono:['',[Validators.required]],
  estadoCivil:['',[Validators.required]],
  agravante:['',[Validators.required]],
  idDepartamentoNac:['',[Validators.required]],
  idMunicipioNac:['',[Validators.required]],
  idDepartamentoDom:['',[Validators.required]],
  idMunicipioDom:['',[Validators.required]],
  ciudadDom:['',[Validators.required]],
  ciudadNac:['',[Validators.required]],
  aldeaNac:['',[Validators.required]],
  aldeaDom:['',[Validators.required]],


});

this.ruta.params.subscribe(param => {
  this.id = param['id'];
})
  }

  getDepartamentos(){
    this._muni_deptService.getDepartamentos().subscribe(res=>{
      this.departamentos=res.lista;
    });
  }

  getMunicipios(idDepartamento:any,tip:number){
    const valor = (idDepartamento.target as HTMLSelectElement).value;

    console.log('valor: ', valor);
    this._muni_deptService.getMunicipios(valor).subscribe(res=>{
      console.log('res: ', res);
      if(tip==1){
        this.municipiosNac=res.lista;
      }else{
        this.municipiosDom=res.lista;
      }

    });
  }

  getMunicipiosNac(idDepartamento:any){

    this._muni_deptService.getMunicipios(idDepartamento).subscribe(res=>{
      this.municipiosNac=res.lista;
    });
  }

  getMunicipiosDom(idDepartamento:any){
    this._muni_deptService.getMunicipios(idDepartamento).subscribe(res=>{
      this.municipiosDom=res.lista;
    });
  }

  getNivelesEducativos(){
    this._nivelEducService.getNivelEducativos().subscribe(res=>{
      this.nivelesEducativos=res.lista;
    })
  }


  volver(){
    this.router.navigate(['home/gestionPersonas/victimas']);

  }

  addEdit(){
    const lista:Persona={
      dni:this.form.value.dni,
      nombreLegal:this.form.value.nombreLegal,
      fechaNacimiento:this.form.value.fechaNacimiento,
      nacionalidad:this.form.value.nacionalidad,
      idNivelEduc:this.form.value.idNivelEduc,
      telefono:this.form.value.telefono,
      estadoCivil:this.form.value.estadoCivil,
      agravantes:this.form.value.agravante,
      idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
      idUsuarioModifico:this._decodedService.decodedTokenIdUsuario(),
      tblLugarNacimientos:[{
        idDepartamento:this.form.value.idDepartamentoNac,
        idMunicipio:this.form.value.idMunicipioNac,
        ciudad:this.form.value.ciudadNac,
        aldea:this.form.value.ciudadNac,
        idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
        idUsuarioModifico:this._decodedService.decodedTokenIdUsuario()
      }],
      tblLugarDomicilios:[{
        idDepartamento:this.form.value.idDepartamentoDom,
        idMunicipio:this.form.value.idMunicipioDom,
        ciudad:this.form.value.ciudadDom,
        aldea:this.form.value.aldeaDom,
        idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),
        idUsuarioModifico:this._decodedService.decodedTokenIdUsuario()
      }]

    };


    if(this.id==0){
      this._personaService.postPersona(lista).subscribe((res:any)=>{
        if(res.ok){
          Swal.fire({
            title: "Agregado!",
            text: "Registro agregado exitosamente !!",
            icon: "success"
          });

          this.router.navigate(['home/gestionPersonas/victimas']);

        }

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
      this._personaService.putPersona(this.id,lista).subscribe((res:any)=>{
        if(res.ok){
          Swal.fire({
            title: "Actualizado!",
            text: "Registro  Actualizado exitosamente !! ",
            icon: "success"
          });

          this.router.navigate(['home/gestionPersonas/victimas']);

        }

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

  getFiltroPersona(id:number){
    this._personaService.getFiltroPersona(id).subscribe(res=>{
      console.log('res: llllll', res);

      this.form.patchValue({
        dni:res.lista.dni,
        nombreLegal:res.lista.nombreLegal,
        fechaNacimiento:res.lista.fechaNacimiento,
        nacionalidad:res.lista.nacionalidad,
        estadoCivil:res.lista.estadoCivil,
        idNivelEduc:res.lista.idNivelEduc,
        telefono:res.lista.telefono,
        agravante:res.lista.agravantes,
        idDepartamentoNac:res.lista.idDepartamentoNac,
        idDepartamentoDom:res.lista.idDepartamentoDom,
        idMunicipioNac:res.lista.idMunicipioNac,
        idMunicipioDom:res.lista.idMunicipioDom,
        ciudadNac:res.lista.ciudadNac,
        ciudadDom:res.lista.ciudadDom,
        aldeaNac:res.lista.aldeaNac,
        aldeaDom:res.lista.aldeaDom

      });

      this.getMunicipiosNac(res.lista.idDepartamentoNac);
      this.getMunicipiosDom(res.lista.idDepartamentoDom);

    });

  }



  selectores(){

  }

  ngOnInit(): void {
    this.getDepartamentos();
    this.getNivelesEducativos();
    this.selectores();

    if(this.id!=0){
      this.getFiltroPersona(this.id);
    }

  }

}
