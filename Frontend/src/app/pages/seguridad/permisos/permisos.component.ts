import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Objeto } from 'src/app/interfaces/objeto';
import { Permiso } from 'src/app/interfaces/permiso';
import { Rol } from 'src/app/interfaces/rol';
import { ObjetosService } from 'src/app/services/objetos.service';
import { PermisosService } from 'src/app/services/permisos.service';
import { RolesService } from 'src/app/services/roles.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-permisos',
  templateUrl: './permisos.component.html',
  styleUrls: ['./permisos.component.css']
})
export class PermisosComponent implements OnInit {

  form:any;
  id!:number;
  roles:any;
  objetosPadre:any;
  objetosHijos:any;
  operacion:string="Agregar ";
  listaPermisos:Permiso[]=[];
  permisos:any;
  dats:any;
  displayedColumns: string[] = ['nombreRol', 'objeto', 'permisoVer','permisoAgregar','permisoEditar','permisoEliminar','permisoReporte', 'estado','editar','eliminar'];
  dataSource!: MatTableDataSource<Permiso>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private fb:FormBuilder,
    private _PermisoService:PermisosService,
    private _rolesService:RolesService,
    private _objetosService:ObjetosService,
    private router:Router,
    private ruta:ActivatedRoute

  ){
    this.form=fb.group({
      idRol:['',[Validators.required]]
    });


  }

  agregarPermiso(){

    const lista:Rol={
      tblPermisos:this.listaPermisos
    }

      this._PermisoService.postPermiso(lista).subscribe((res:any)=>{
        Swal.fire({
          title: "Agregado!",
          text: "Permiso agregado exitosamente ",
          icon: "success"
        });

        this.router.navigate(['home/seguridad/permisos']);
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

  getRoles(){
    this._rolesService.getRoles().subscribe(res=>{
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

  getObjetos(){
    this._objetosService.getObjeto().subscribe(res=>{
      this.objetosPadre=res.lista.filter((x:Objeto)=>x.estado==1 && x.idObjetoPadre==1 && x.idObjeto!==1 );
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

    })
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  getPermisos(){
    this._PermisoService.getPermisos().subscribe(res=>{
      console.log('res: ', res);
      this.dataSource=res.lista;
      this.dataSource = new MatTableDataSource(res.lista);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;


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

  cargarObjetosHijos( idObjetoPadre:number){
    this._objetosService.getObjeto().subscribe(res=>{
      this.objetosHijos=res.lista.filter((x:Objeto)=>x.estado==1 && x.idObjetoPadre==idObjetoPadre );
      console.log('this.objetosHijos: ', this.objetosHijos);
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

    })

  }

  actualizarEstado(id:number, estado:number){

  }

  agregarObjetoHijo(id:number){
    const Objeto =this.listaPermisos.some(x=>x.idObjeto==id);
    if(!Objeto){
      this.listaPermisos.push({idRol:this.form.value.idRol, idObjeto:id});
      console.log('this.listaPermisos: ', this.listaPermisos);
      // setTimeout(() => {
      //   this.listaPermisos.push(id);
      // }, 600);

    }
  }

  quitarObjetoHijo(id:number){
    const index = this.listaPermisos.findIndex(x=>x.idObjeto==id);
    if(index!==-1){
      this.listaPermisos.splice(index, 1);
      console.log('this.listaPermisos: ', this.listaPermisos);
    }

  }

  volver(){
    this.router.navigate(['home/seguridad/Permisoes'])
  }

  // getFiltroPermiso(id:number){
  //   this._PermisoService.getFiltroPermiso(id).subscribe(res=>{
  //     this.form.patchValue({
  //       nombrePermiso:res.lista.nombrePermiso,
  //       descripcion:res.lista.descripcion
  //     });
  //   },
  //   err=>{
  //     const Toast = Swal.mixin({
  //       toast: true,
  //       position: 'top-end',
  //       showConfirmButton: false,
  //       width:500,
  //       timer: 7000,
  //       timerProgressBar: true,
  //       didOpen: (toast) => {
  //         toast.addEventListener('mouseenter', Swal.stopTimer)
  //         toast.addEventListener('mouseleave', Swal.resumeTimer)
  //       }
  //     })

  //     Toast.fire({
  //       icon: 'error',
  //       title: `Error de Servidor. Intente nuevamente!!`
  //     });
  //   });

  // }

  ngOnInit(): void {
    // if(this.id!=0){
    //   // this.operacion="Editar ";
    //   // this.getFiltroPermiso(this.id);

    // }
    this.getRoles();
    this.getObjetos();
    this.getPermisos();

  }

}
