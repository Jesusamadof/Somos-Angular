import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Login } from 'src/app/interfaces/login';
import { AuthService } from 'src/app/services/auth.service';
import { PreguntasService } from 'src/app/services/preguntas.service';
import Swal from 'sweetalert2';
import { RecuperarContrasenaComponent } from '../recuperar-contrasena/recuperar-contrasena.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CryptoService } from 'src/app/services/crypto.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  form:FormGroup;
  mostrar:string='fa fa-eye-slash';
  password: string = '';
  hidePassword: boolean = true;
  errorStatus: boolean = false;
  errorMsj: any = '';
  token: any;
  mensaje!: string;
  validar: any;
  preguntas:any;

   dats:any;
     constructor (private fb:FormBuilder,
     private auth:AuthService,
     private router:Router,
     private _preguntasService:PreguntasService,
     private dialog:MatDialog,
     private _snackbar:MatSnackBar,
      private  _cryptoService:CryptoService
      ){
      this.form=fb.group({
        usuario:['cristian', [Validators.required]],
        contrasena:['1234', [Validators.required]],
      })
     }

  togglePasswordVisibility(): void {
    this.hidePassword = !this.hidePassword;
  }

  mostrarPass(){
    this.mostrar='fa fa-eye';
  }
  hide = true;
  dt: any;


  acceder(){
const login:Login={
  usuario:this.form.value.usuario,
  contrasena:this.form.value.contrasena

}

    this.auth.login(login).subscribe(res=>{
      this.dt = res;
      console.log('reshhhh: ', res);

      if (this.dt.ok) {
        const encryptedUserId = this._cryptoService.encrypt(this.dt.lista.idUsuario.toString());
        const encryptedUsername = this._cryptoService.encrypt(this.dt.lista.usuario);
        const encryptedFullName = this._cryptoService.encrypt(this.dt.lista.nombre);
        if (this.dt.cambioContrasena == 1 || this.dt.contrasenaSegura==0) {
       this.router.navigate([`auth/cambiarContrasena`]);
       this.router.navigate([`auth/cambiarContrasena`, encryptedUserId, encryptedUsername, encryptedFullName]);
           this._snackbar.open('Debe de cambiar la contraseña, para poder acceder al sistema.', 'Cerrar',{
       horizontalPosition: 'center',
        verticalPosition: 'top',
        duration:10000

    })
        } else if(this.dt.preguntas.length==0){
          this.router.navigate([`auth/preguntasUsuario`,encryptedUserId,encryptedUsername,encryptedFullName]);
        }else {
          localStorage.setItem('token', this.dt.token);
          this.router.navigate(['home/dashboard']);
        }
      } else {

        this.mensaje = this.dt.mensaje;
        this.validar = this.dt.ok;
        const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
          showConfirmButton: false,
        width:500,
        timer: 5000,
        timerProgressBar: true,
        didOpen: (toast) => {
          toast.addEventListener('mouseenter', Swal.stopTimer)
          toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
      })

      Toast.fire({
        icon: 'error',
        title: `${this.mensaje}`
      })


        localStorage.removeItem('token');
      }
  //     this.token= localStorage.getItem('token');
  // const decodedToken= jwtDecode(this.token);
  //   console.log("decodifocacion",decodedToken)

    }, error => {
      console.log('error: ', error);
      const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        width:500,
        timer: 5000,
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
    }
  );


  }

getPreguntasUsu(id:number){
  this._preguntasService.getPreguntasUsuario(id).subscribe(res=>{
    this.preguntas=res.lista;
  });
}


recuperarContrasena(): void {
    const dialogRef = this.dialog.open(RecuperarContrasenaComponent, {
      width:'400px'
      //data: {name: this.name, animal: this.animal},
    });
}


}
