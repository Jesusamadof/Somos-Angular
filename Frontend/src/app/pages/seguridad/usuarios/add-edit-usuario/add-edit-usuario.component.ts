import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Rol } from 'src/app/interfaces/rol';
import { Usuario } from 'src/app/interfaces/usuario';
import { RolesService } from 'src/app/services/roles.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-usuario',
  templateUrl: './add-edit-usuario.component.html',
  styleUrls: ['./add-edit-usuario.component.css']
})
export class AddEditUsuarioComponent implements OnInit {


  form:any;
  id!:number;
  operacion:string="Agregar ";
  roles:any;

  constructor(
    private fb:FormBuilder,
    private _UsuarioService:UsuarioService,
    private router:Router,
    private ruta:ActivatedRoute,
    private _rolService:RolesService

  ){
    this.form=fb.group({
      nombre:['',[Validators.required]],
      idRol:['',Validators.required],
      usuario:['',Validators.required],
      correo:['',[Validators.required,Validators.email]],
    });

    this.ruta.params.subscribe(param => {
      this.id = param['id'];
    })

  }

  agregarUsuario(){
    const lista:Usuario={
      nombre:this.form.value.nombre,
      usuario:this.form.value.usuario,
      correo:this.form.value.correo,
      idRol:this.form.value.idRol,
    }
    if(this.id==0){
      this._UsuarioService.postUsuario(lista).subscribe(res=>{
        Swal.fire({
          title: "Agregado!",
          text: "Usuario agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/usuarios']);
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
      this._UsuarioService.putUsuario(this.id,lista).subscribe(res=>{
        Swal.fire({
          title: "Actualizado!",
          text: "Usuario Actualizado exitosamente !! ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/usuarios']);
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
    this.router.navigate(['home/seguridad/usuarios'])
  }

  getFiltroUsuario(id:number){
    this._UsuarioService.getFiltroUsuario(id).subscribe(res=>{
      console.log('res:patcj ', res);
      this.form.patchValue({
        nombrelegal:res.lista.nombrelegal,
        usuario:res.lista.usuario,
        correo:res.lista.correo,
        idRol:res.lista.idRol,
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

  getRoles(){
    this._rolService.getRoles().subscribe(res=>{
      this.roles=res.lista.filter((x:Rol)=>x.estado==1);
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

  }

  ngOnInit(): void {
    this.getRoles();
    if(this.id!=0){
      this.operacion="Editar ";
      this.getFiltroUsuario(this.id);

    }

  }

}


