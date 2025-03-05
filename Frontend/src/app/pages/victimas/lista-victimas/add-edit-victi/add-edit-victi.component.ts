import { DecodedService } from 'src/app/services/decoded.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Dependencia } from 'src/app/interfaces/dependencia';
import { DependienteVictima } from 'src/app/interfaces/dependiente-victima';
import { Organizacion } from 'src/app/interfaces/organizacion';
import { OrganizacionVictima } from 'src/app/interfaces/organizacion-victima';
import { CondicionMigratoriaService } from 'src/app/services/condicion-migratoria.service';
import { DependenciaService } from 'src/app/services/dependencia.service';
import { EtniaService } from 'src/app/services/etnia.service';
import { ExpresionGeneroService } from 'src/app/services/expresion-genero.service';
import { GeneradorHechoService } from 'src/app/services/generador-hecho.service';
import { GenerosService } from 'src/app/services/generos.service';
import { OrganizacionService } from 'src/app/services/organizacion.service';
import { OrientacionSexualService } from 'src/app/services/orientacion-sexual.service';
import { PersonasService } from 'src/app/services/personas.service';
import Swal from 'sweetalert2';
import { Victima } from 'src/app/interfaces/victima';
import { VictimasService } from 'src/app/services/victimas.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-edit-victi',
  templateUrl: './add-edit-victi.component.html',
  styleUrls: ['./add-edit-victi.component.css']
})
export class AddEditVictiComponent implements OnInit {
  form:FormGroup;
  operacion:string="Agregar "
  dependientes:DependienteVictima[]=[];
  organizaciones:OrganizacionVictima[]=[];
  organizacionesLista:OrganizacionVictima[]=[];
  dependientesLista:DependienteVictima[]=[];
  personas:any;
  generos:any;
  expresionesGeneros:any;
  orientacionesSexuales:any;
  condicionesMigr:any;
  etnias:any;
  generadoresHechos:any;
  dependiente:any;
  organizacion:any;
  mostrarSelOrganizacion:boolean=false;
  id:any;



  constructor(
    private fb:FormBuilder,
    private _personaService:PersonasService,
    private _generosService:GenerosService,
    private _expresionGeService: ExpresionGeneroService,
    private _orientacionSex:OrientacionSexualService,
    private _condicionMigr:CondicionMigratoriaService,
    private _etniaService:EtniaService,
    private _generadorHechoService:GeneradorHechoService,
    private _dependenciaService:DependenciaService,
    private _organizacionService:OrganizacionService,
    private _decodedService:DecodedService,
    private _victimaService:VictimasService,
    private router:Router,
    private ruta:ActivatedRoute,
  ){
    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

    this.form=fb.group({
      idPersona:['',[Validators.required]],
      nombre_legal:['',[Validators.required]],
      cambio_nom_legal:['',[Validators.required]],
      nombre_ident_genero:['',[Validators.required]],
      otro_nombre:['',[Validators.required]],
      id_genero_victima:['',[Validators.required]],
      id_expr_genero:['',[Validators.required]],
      id_orientacion:['',[Validators.required]],
      ocupacion:['',[Validators.required]],
      discapacidad_victima:['',[Validators.required]], //SI, NO
      id_condicion_migratoria:['',[Validators.required]],
      id_etnia:['',[Validators.required]],
      hijos:['',[Validators.required]], //SI,NO
      cant_hijos:['',[Validators.required]],
      cant_hijos_may:['',[Validators.required]],
      cant_hijos_men:['',[Validators.required]],
      cant_person_dependiente:['',[Validators.required]],// lista de organizacion pendiente
      perteneciente_ong:['',[Validators.required]], // SI,NO lista pendiente de organizaciones
      denucia_previa:['',[Validators.required]], //SI, NO
      numero_caso:['',[Validators.required]],
      tipo_denuncia:['',[Validators.required]],
      nomb_institu_denuncio:['',[Validators.required]],
      medidad_proteccion:['',[Validators.required]],
     tipo_medida_protec:['',[Validators.required]],
      id_generador:['',[Validators.required]]
    });

      this.form.get('cant_hijos')?.disable();
      this.form.get('cant_hijos_may')?.disable();
      this.form.get('cant_hijos_men')?.disable();
      this.form.get('cant_hijos')?.clearValidators();
      this.form.get('cant_hijos_may')?.clearValidators();
      this.form.get('cant_hijos_men')?.clearValidators()





  }



  ngOnInit(): void {
    this.getVictima();
    this.getGeneros();
    this.getExpresionGeneros();
    this.getCondicionesMigr();
    this.getDependientes();
    this.getEtnias();
    this.getGeneradorHecho();
    this.getOrganizaciones();
    this.getOrientacionesSex();
    if(this.id!=='0'){
      this.getfiltroVictima(this.id);
      this.cargarDependencia(this.id);
      this.cargarOrganizacion(this.id);
      this.operacion="Editar ";
    }

  }


volver(){
  this.router.navigate(['home/victimas/lista_victimas']);


}
addEdit(){
  const lista:Victima={
    idPersona:this.form.value.idPersona,
    nombreLegal:this.form.value.nombre_legal,
    cambioNomLegalVictima:this.form.value.cambio_nom_legal,
    nombreIdentGenero:this.form.value.nombre_ident_genero,
    otroNombres:this.form.value.otro_nombre,
    idGeneroVictima:this.form.value.id_genero_victima,
    idExpresionGenero:this.form.value.id_expr_genero,
    idOrientacion:this.form.value.id_orientacion,
    ocupacion:this.form.value.ocupacion,
    discapacidadVictima:this.form.value.discapacidad_victima,
    idCondicionMigratoria:this.form.value.id_condicion_migratoria,
    idEtnia:this.form.value.id_etnia,
    hijos:this.form.value.hijos,
    cantHijos:this.form.value.cant_hijos,
    cantHijosMen:this.form.value.cant_hijos_men,
    cantHijosMay:this.form.value.cant_hijos_may,
    cantPersDependiente:this.form.value.cant_person_dependiente,
    pertenecienteOrganizacion:this.form.value.perteneciente_ong,
    denuciaPrevia:this.form.value.denucia_previa,
    numeroCaso:this.form.value.numero_caso,
    tipoDenucia:this.form.value.tipo_denuncia,
    nomInstiDenucia:this.form.value.nomb_institu_denuncio,
    medidasProteccion:this.form.value.medidad_proteccion,
    tipoMedProteccion:this.form.value.tipo_medida_protec,
    idGeneradorHecho:this.form.value.id_generador,
    tblDetDepenVictimas:this.dependientesLista,
    tblDetOrganVictimas:this.organizacionesLista

  }

  if(this.id==0){
    this._victimaService.postVictima(lista).subscribe((res:any)=>{
      if(res.ok){
        Swal.fire({
          title: "Agregado!",
          text: "Registro agregado exitosamente !!",
          icon: "success"
        });

        this.router.navigate(['home/victimas/victimas']);

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
    this._victimaService.putVictima(this.id,lista).subscribe((res:any)=>{
      if(res.ok){
        Swal.fire({
          title: "Actualizado!",
          text: "Registro  Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/victimas/lista_victimas']);

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

agregarDependiente(evento:any){
  const item = (evento.target as HTMLInputElement).value;
  const valor= JSON.parse(item);
  console.log('dep: ', valor);
  if(!this.dependientes.some((x:Dependencia)=>x.idDependiente==valor.idDependiente) && !this.dependientesLista.some((x:DependienteVictima)=>x.idDependiente==valor.idDependiente)){

    this.dependientes.push({idDetDepVictima:undefined,idDependiente:valor.idDependiente, tipoDependiente:valor.tipoDependiente});
    this.dependientesLista.push({idDetDepVictima:undefined,idDependiente:valor.idDependiente,idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),idUsuarioModifico:this._decodedService.decodedTokenIdUsuario()});
    console.log(' this.dependientesLista: ',  this.dependientesLista);

    console.log('this.dependientes: ', this.dependientes);
  }else{
    Swal.fire({
      title: "Error!",
      text: "Dependiente ya existe, seleccione otro !!",
      icon: "error"
    });
  }

}

cargarDependencia(id:number){
  this._victimaService.getCargarDependientes(id).subscribe((res:any)=>{
    if(res.ok){
      for (let index = 0; index < res.lista.length; index++) {
        this.dependientes.push({idDetDepVictima:res.lista[index].idDetDepVictima,idDependiente:res.lista[index].idDependiente,tipoDependiente:res.lista[index].tipoDependiente});
        this.dependientesLista.push({idDetDepVictima:res.lista[index].idDetDepVictima,idDependiente:res.lista[index].idDependiente})



      }

    }
  })
}

cargarOrganizacion(id:number){
  this._victimaService.getCargarOrganizaciones(id).subscribe((res:any)=>{
    if(res.ok){
      this.mostrarSelOrganizacion=true;

      for (let index = 0; index < res.lista.length; index++) {
        this.organizaciones.push({idDetOrganVictima:res.lista[index].idDetOrganVictima,idOrganizacion:res.lista[index].idOrganizacion,nombreOrganizacion:res.lista[index].nombreOrganizacion});    ;
        this.organizacionesLista.push({idDetOrganVictima:res.lista[index].idDetOrganVictima,idOrganizacion:res.lista[index].idOrganizacion,nombreOrganizacion:res.lista[index].nombreOrganizacion});    ;



      }
    }
   })
}



agregarOrganizacion(evento:any){
  const item = (evento.target as HTMLInputElement).value;
  const valor= JSON.parse(item);
  if(!this.organizaciones.some((x:Organizacion)=>x.idOrganizacion==valor.idOrganizacion ) && !this.organizacionesLista.some((x:OrganizacionVictima)=>x.idOrganizacion==valor.idOrganizacion )){

    this.organizaciones.push({idDetOrganVictima:undefined,idOrganizacion:valor.idOrganizacion, nombreOrganizacion:valor.nombreOrganizacion});
    this.organizacionesLista.push({idDetOrganVictima:undefined, idOrganizacion:valor.idOrganizacion,idUsuarioCreo:this._decodedService.decodedTokenIdUsuario(),idUsuarioModifico:this._decodedService.decodedTokenIdUsuario()});
    console.log(' this.organizacionesLis: ',  this.organizacionesLista);
    console.log('this.dependientes: ', this.organizaciones);
  }else{
    Swal.fire({
      title: "Error!",
      text: "Organización ya existe, seleccione otra !!",
      icon: "error"
    });
  }

}

quitarDependiente(id:any){
  console.log('id: ', id);
  const index = this.dependientes.findIndex((x:Dependencia)=>x.idDependiente==id);
  const index1 = this.dependientesLista.findIndex((x:DependienteVictima)=>x.idDependiente==id);
  if(index!==-1 && index1!==-1){
    this.dependientes.splice(index,1);
    this.dependientesLista.splice(index1,1);
  }
}

quitarOrganizacion(id:any){
  console.log('id: ', id);
  const index = this.organizaciones.findIndex((x:Organizacion)=>x.idOrganizacion==id);
  const index1 = this.organizacionesLista.findIndex((x:OrganizacionVictima)=>x.idOrganizacion==id);
  if(index!==-1 && index1!==-1){
    this.organizaciones.splice(index,1);
    this.organizacionesLista.splice(index1,1);
  }
}

eliminarDependiente(id:number){

  const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
      confirmButton: 'btn btn-success mr-8',
      cancelButton: 'btn btn-danger'
    },
    buttonsStyling: false
  })

  swalWithBootstrapButtons.fire({
    title: '¿Desea Eliminar esta dependencia?',
    text: "Recuerde que no podra recuperar el registro!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Si, Eliminar!  ',
    cancelButtonText: 'No, cancelar!  ',
    reverseButtons: true
  }).then((result) => {
    if (result.isConfirmed) {
      const lista:Victima={
        estadoEliminacion:1
      }
      this._victimaService.eliminarDependencias(id).subscribe((res:any) => {
        console.log('resjkhsjkdjk: ', res);
        if (res.ok) {
          const index = this.dependientes.findIndex((x:DependienteVictima)=>x.idDetDepVictima==id);
          const index1 = this.dependientesLista.findIndex((x:DependienteVictima)=>x.idDetDepVictima==id);
          if(index!==-1 && index1!==-1){
            this.dependientes.splice(index,1);
            this.dependientesLista.splice(index1,1);
          }

          swalWithBootstrapButtons.fire(
            'Eliminado!!',
            'El registro ha sido eliminado!',
            'success'
          )
          //window.location.reload();
          this.getVictima();

        } else {
          swalWithBootstrapButtons.fire(
            'Error!!',
            'No Se Pudo Eliminar!',
            'error'
          );
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

    } else if (
      /* Read more about handling dismissals below */
      result.dismiss === Swal.DismissReason.cancel
    ) {
      swalWithBootstrapButtons.fire(
        'Cancelado!',
        'El registro no se elimino :)',
        'error'
      )
    }
  }, error => {
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
    })
  });



}

eliminarOrganizacion(id:number){

  const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
      confirmButton: 'btn btn-success mr-8',
      cancelButton: 'btn btn-danger'
    },
    buttonsStyling: false
  })

  swalWithBootstrapButtons.fire({
    title: '¿Desea Eliminar esta organización?',
    text: "Recuerde que no podra recuperar el registro!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Si, Eliminar!  ',
    cancelButtonText: 'No, cancelar!  ',
    reverseButtons: true
  }).then((result) => {
    if (result.isConfirmed) {
      const lista:Victima={
        estadoEliminacion:1
      }
      this._victimaService.eliminarOrganizaciones(id).subscribe((res:any) => {
        if (res.ok) {
          const index = this.organizaciones.findIndex((x:OrganizacionVictima)=>x.idDetOrganVictima==id);
          const index1 = this.organizacionesLista.findIndex((x:OrganizacionVictima)=>x.idDetOrganVictima==id);
          if(index!==-1 && index1!==-1){
            this.organizaciones.splice(index,1);
            this.organizacionesLista.splice(index1,1);
          }


          swalWithBootstrapButtons.fire(
            'Eliminado!!',
            'El registro ha sido eliminado!',
            'success'
          )
          //window.location.reload();
          this.getVictima();

        } else {
          swalWithBootstrapButtons.fire(
            'Error!!',
            'No Se Pudo Eliminar!',
            'error'
          );
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

    } else if (
      /* Read more about handling dismissals below */
      result.dismiss === Swal.DismissReason.cancel
    ) {
      swalWithBootstrapButtons.fire(
        'Cancelado!',
        'El registro no se elimino :)',
        'error'
      )
    }
  }, error => {
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
    })
  });

}

hijos( evento:any){
  console.log('event: ', event);
    if(this.form.value.hijos==1){

    this.form.get('cant_hijos')?.enable();
    this.form.get('cant_hijos_may')?.enable();
    this.form.get('cant_hijos_men')?.enable();
    this.form.get('cant_hijos')?.setValue('');
    this.form.get('cant_hijos_may')?.setValue('');
    this.form.get('cant_hijos_men')?.setValue('');
    this.form.get('cant_hijos')?.setValidators([Validators.required]);
    this.form.get('cant_hijos_may')?.setValidators([Validators.required]);
    this.form.get('cant_hijos_men')?.setValidators([Validators.required]);


  }else{
    this.form.get('cant_hijos')?.disable();
    this.form.get('cant_hijos_may')?.disable();
    this.form.get('cant_hijos_men')?.disable();
    this.form.get('cant_hijos')?.setValue('0');
    this.form.get('cant_hijos_may')?.setValue('0');
    this.form.get('cant_hijos_men')?.setValue('0');
    this.form.get('cant_hijos')?.clearValidators();
    this.form.get('cant_hijos_may')?.clearValidators();
    this.form.get('cant_hijos_men')?.clearValidators()

  }


}

organiz(event:any){

  if(this.form.value.perteneciente_ong=='1'){
    this.mostrarSelOrganizacion=true;

  }else{
    this.mostrarSelOrganizacion=false
  }

}



getfiltroVictima(id:number){
  this._victimaService.getFiltroVictima(id).subscribe(res=>{
    console.log('res: ', res);
    this.form.patchValue({
      idPersona:res.lista.idPersona,
      nombre_legal:res.lista.nombreLegal,
      cambio_nom_legal:res.lista.cambioNomLegalVictima,
      nombre_ident_genero:res.lista.nombreIdentGenero,
      otro_nombre:res.lista.otroNombres,
      id_genero_victima:res.lista.idGeneroVictima,
      id_expr_genero:res.lista.idExpresionGenero,
      id_orientacion:res.lista.idOrientacion,
      ocupacion:res.lista.ocupacion,
      discapacidad_victima:res.lista.discapacidadVictima, //SI, NO
      id_condicion_migratoria:res.lista.idCondicionMigratoria,
      id_etnia:res.lista.idEtnia,
      hijos:res.lista.hijos, //SI,NO
      cant_hijos:res.lista.cantHijos,
      cant_hijos_may:res.lista.cantHijosMay,
      cant_hijos_men:res.lista.cantHijosMen,
      cant_person_dependiente:res.lista.cantPersDependiente,// lista de organizacion pendiente
      perteneciente_ong:res.lista.pertenecienteOrganizacion, // SI,NO lista pendiente de organizaciones
      denucia_previa:res.lista.denuciaPrevia, //SI, NO
      numero_caso:res.lista.numeroCaso,
      tipo_denuncia:res.lista.tipoDenucia,
      nomb_institu_denuncio:res.lista.nomInstiDenucia,
      medidad_proteccion:res.lista.medidasProteccion,
     tipo_medida_protec:res.lista.tipoMedProteccion,
      id_generador:res.lista.idGeneradorHecho

    });

  });

}

getVictima(){
  this._personaService.getPersonas().subscribe(res=>{
    this.personas=res.lista;
  });
}

  getGeneros(){
    this._generosService.getGeneros().subscribe(res=>{
      this.generos=res.lista;
    });

}

getExpresionGeneros(){
  this._expresionGeService.getExpresionGeneros().subscribe(res=>{
    this.expresionesGeneros=res.lista;
  });
}

getOrientacionesSex(){
  this._orientacionSex.getOrientacion().subscribe(res=>{
    this.orientacionesSexuales=res.lista;
  });
}
getEtnias(){
  this._etniaService.getEtniaes().subscribe(res=>{
    this.etnias=res.lista;
  });
}

getCondicionesMigr(){
  this._condicionMigr.getCondicionMigratoriaes().subscribe(res=>{
    this.condicionesMigr=res.lista;
  });
}

getGeneradorHecho(){
  this._generadorHechoService.getGeneradorHechos().subscribe(res=>{
    this.generadoresHechos=res.lista;
  });
}

getDependientes(){
  this._dependenciaService.getDependencias().subscribe(res=>{
    this.dependiente=res.lista;
  });
}

getOrganizaciones(){
  this._organizacionService.getOrganizaciones().subscribe(res=>{
    this.organizacion=res.lista;
  });
}

}
