import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Pregunta } from 'src/app/interfaces/pregunta';
import { PreguntasUsuario } from 'src/app/interfaces/preguntas-usuario';
import { Usuario } from 'src/app/interfaces/usuario';
import { CryptoService } from 'src/app/services/crypto.service';
import { PreguntasService } from 'src/app/services/preguntas.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-preguntas-usuario',
  templateUrl: './preguntas-usuario.component.html',
  styleUrls: ['./preguntas-usuario.component.css']
})
export class PreguntasUsuarioComponent implements OnInit {

form:any;
  errorStatus: boolean = false;
  errorMsj: any = '';
  token: any;
  mensaje!: string;
  validarContrasena: any;
  id: any;
  nombre: any;
  usuario: any;
  preguntas:any;
  preguntasLista:PreguntasUsuario[]=[];

  constructor(
    private route: ActivatedRoute,
    private ruta:Router,
    private fb: FormBuilder,
    private _usuarioService: UsuarioService,
    private _snackBar: MatSnackBar,
     private _cryptoService: CryptoService,
     private _preguntasUsuario:PreguntasService

  ) {
    this.form = this.fb.group({
      idPregunta: ['', [Validators.required]],
      respuesta:['',[Validators.required]]
    })

  }

  convertirAMayusculas(event: any) {
    const valor = event.target.value;
    this.form.get('respuesta')?.setValue(valor.toUpperCase());
  }

  dats: any;





  dt: any;

  agregarRepuesta(){
    if(!this.preguntasLista.some((x:PreguntasUsuario)=>x.idPregunta==this.form.value.idPregunta)){
      this.preguntasLista.push({
        idUsuario:this.id,
        idPregunta:this.form.value.idPregunta,
        respuesta:this.form.value.respuesta,
        idUsuarioCreo:this.id
      });

      this.form.get('idPregunta').setValue('');
      this.form.get('respuesta').setValue('');
      Swal.fire({
        title: "Exitoso!",
        text: "La pregunta seleccionada fue agregada exitosamente!! ",
        icon: "success"
      });

    }else{
      this.form.get('idPregunta').setValue('');
      this.form.get('respuesta').setValue('');
      Swal.fire({
        title: "Error!",
        text: "La pregunta seleccionada ya existe, agregue otra!! ",
        icon: "error"
      });

    }


  }

  verif(id:number): boolean{
    const val=this.preguntasLista.some((x:any)=>x.idPregunta===id);

   return val;

  }


  quitarPregunta(id:any){
    const index = this.preguntasLista.findIndex((x:PreguntasUsuario)=>x.idPregunta==this.form.value.idPregunta);
    if(index==-1){
      this.preguntasLista.splice(index,1);
    }
  }

  getPreguntas(){
    this._preguntasUsuario.getPreguntas().subscribe(res=>{
      this.preguntas=res.lista;
    });
  }

 guardar() {
 const lista:Usuario={
   tblPreguntaUsuarios:this.preguntasLista
  }


this._usuarioService.postPreguntasUsuario(lista).subscribe((res:any)=>{
if(res.ok){
  Swal.fire({
    title: "Exitoso!",
    text: "La pregunta seleccionadas fue agregadas exitosamente!! ",
    icon: "success"
  });
  this.ruta.navigate(['login']);

}

});

    // this.route.params.subscribe(param => {
    //   this.id = param['id'];
    //   this.nombre = param['nombre'];
    //   this.usuario = param['usuario'];

    // })
  }
  ngOnInit(): void {
    this.getPreguntas();
        this.route.params.subscribe(param => {
      console.log('param: ', param);
      this.id = this._cryptoService.decrypt(param['id']) ;
      this.nombre =this._cryptoService.decrypt(param['nombre']);
      this.usuario = this._cryptoService.decrypt(param['usuario']);

    })
  }

}
