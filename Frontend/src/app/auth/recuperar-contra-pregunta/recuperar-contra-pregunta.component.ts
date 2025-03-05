import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { PreguntasUsuario } from 'src/app/interfaces/preguntas-usuario';
import { CryptoService } from 'src/app/services/crypto.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-recuperar-contra-pregunta',
  templateUrl: './recuperar-contra-pregunta.component.html',
  styleUrls: ['./recuperar-contra-pregunta.component.css']
})
export class RecuperarContraPreguntaComponent implements OnInit {
form:FormGroup;
preguntas:any;
dt:any;

constructor(
  private fb:FormBuilder,
  private _usuarioService: UsuarioService,
  private router:Router,
  private _cryptoService:CryptoService
  ){
  this.form=fb.group({
    respuesta:[''],
    idPregunta:['']
  });




}

getPreguntas(evento:any){
  const valor = ((evento.target) as HTMLInputElement).value
  console.log('valor: ', valor);
  this._usuarioService.getFiltroPreguntasUsuario(valor).subscribe(res=>{
    console.log('res: jj', res);
    this.preguntas=res.lista;

  });

}
convertirAMayusculas(event: any) {
  const valor = event.target.value;
  this.form.get('respuesta')?.setValue(valor.toUpperCase());
}

verificar(){
  const lista:PreguntasUsuario={
    respuesta:this.form.value.respuesta,
    idPregunta:this.form.value.idPregunta
  }
  this._usuarioService.postRespuestaPreguntasUsuario(lista).subscribe((res:any)=>{
    console.log('res: nnnn', res);
    this.dt=res;
    if(res.ok){
      const encryptedUserId = this._cryptoService.encrypt(this.dt.lista[0].idUsuario.toString());
        const encryptedUsername = this._cryptoService.encrypt(this.dt.lista[0].usuario);
        const encryptedFullName = this._cryptoService.encrypt(this.dt.lista[0].nombre);
      this.router.navigate(['auth/cambiarContrasena',encryptedUserId,encryptedUsername,encryptedFullName]);
      Swal.fire({
        title: "Exitoso!",
        text: "Respuesta correcta!! ",
        icon: "success"
      });



    }else{
      Swal.fire({
        title: "Error!",
        text: "La respuesta ingresada es incorrecta, pruebe con otra pregunta!! ",
        icon: "error"
      });
    }

  })
}


 ngOnInit(): void {


 }
}
