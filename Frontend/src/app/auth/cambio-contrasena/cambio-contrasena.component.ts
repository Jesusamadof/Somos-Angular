import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CryptoService } from 'src/app/services/crypto.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cambio-contrasena',
  templateUrl: './cambio-contrasena.component.html',
  styleUrls: ['./cambio-contrasena.component.css']
})
export class CambioContrasenaComponent implements OnInit {
  form:any;
  mostrar:string='fa fa-eye-slash';
  password: string = '';
  hidePassword1: boolean = true;
  hidePassword2: boolean = true;
  errorStatus: boolean = false;
  errorMsj: any = '';
  token: any;
  mensaje!: string;
  validarContrasena: any;
  id: any;
  nombre: any;
  usuario: any;

  constructor(
    private route: ActivatedRoute,
    private ruta:Router,
    private fb: FormBuilder,
    private _usuarioService: UsuarioService,
    private _snackBar: MatSnackBar,
     private _cryptoService: CryptoService,
  ) {
    this.form = this.fb.group({
      contrasena: ['', [Validators.required, Validators.minLength(8),    Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?":{}|<>]).+/)]],
      confirmarContrasena:['',[Validators.required]]
    })
    console.log(this.form.valid)
  }

  dats: any;


    login={
    usuario:'alex.morales',
    contrasena:'1234'
  }

  togglePasswordVisibility1(): void {
    this.hidePassword1 = !this.hidePassword1;
  }

   togglePasswordVisibility2(): void {
    this.hidePassword2 = !this.hidePassword2;
  }

  mostrarPass(){
    this.mostrar='fa fa-eye';
  }
  hide = true;
  dt: any;



 guardar() {
    if (this.form.value.contrasena == this.form.value.confirmarContrasena) {
      this.validarContrasena = true;
      const datos = {
        contrasena:this.form.value.contrasena
      }
      this._usuarioService.cambioContrasena(this.id, datos).subscribe(res => {
        this.ruta.navigate(['login']);

        this._snackBar.open('Contraseña Reemplazada Exitosamente!!', 'Cerrar', {
          horizontalPosition: 'center',
          verticalPosition: 'top',
          duration: 5000
        });
      }, error => {

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

      })


    } else {
      this.validarContrasena = false;
      console.log("entro",this.form.value.contrasena, this.form.value.confirmarContrasena);
    }


    // this.route.params.subscribe(param => {
    //   this.id = param['id'];
    //   this.nombre = param['nombre'];
    //   this.usuario = param['usuario'];

    // })
  }
  ngOnInit(): void {

        this.route.params.subscribe(param => {
      console.log('param: ', param);
      this.id = this._cryptoService.decrypt(param['id']) ;
      this.nombre =this._cryptoService.decrypt(param['nombre']);
      this.usuario = this._cryptoService.decrypt(param['usuario']);

    })
  }

}
