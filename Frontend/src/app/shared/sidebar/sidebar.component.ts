import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { Permiso } from 'src/app/interfaces/permiso';
import { PermisosService } from 'src/app/services/permisos.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {
  activateRouterHijo!:string;
  activarHijo:string='inactive';
  activarPadre:string='menu-close';
  activateRouterPadre!: any;
  decoded: any;
  datsPermisosPadre: any;
  datsPermisosHijo: any;
  colap: string="z-index:1038";

  constructor(
    private router: Router,
    private _permisoService:PermisosService

  ) { }

  modulohijo(moduloHijo: string) {

    localStorage.setItem('activeRouteHijo', moduloHijo);
    const verLocalStorage= localStorage.getItem('activeRouteHijo');
    this.activateRouterHijo = localStorage.getItem('activeRouteHijo') ||'';

    if(verLocalStorage==moduloHijo){
      this.activarHijo='active'
    }else{
      this.activarHijo='inactive'
    }

  }

  cambioMenu(verif?: boolean) {
    console.log('verif: ', verif);
    if (verif == true) {
      console.log('jojo');
      this.colap = "z-index:999";
    } else {
      this.colap = "z-index:1038";
    }

  }

  modulopadre(modulopadre: string) {

    localStorage.setItem("activeRoutePadre",modulopadre);
    const verLocalStorage=localStorage.getItem('activeRoutePadre');
    this.activateRouterPadre = localStorage.getItem('activeRoutePadre');

    if (verLocalStorage !== modulopadre.toString()) {
       this.cargarModulosPadre();
      this.activarHijo = 'inactive'

    } else {
      this.activarHijo = 'active'
    }

  }

    isAbierto = false; // Inicialmente cerrado

  toggleElement() {
    this.isAbierto = !this.isAbierto; // Alternar el estado (abrir/cerrar)
  }

  getLocalStorage(){
    this.activateRouterHijo = localStorage.getItem('activeRouteHijo') ||'';
    this.activateRouterPadre = localStorage.getItem('activeRoutePadre') ||'';

  }

  cargarModulosPadre() {
        const token = localStorage.getItem('token');
    this.decoded = jwtDecode(token!);
    this._permisoService.getPermisoPadres(this.decoded.idRol).subscribe(res => {
      console.log('res:padre ', res);
      if(res.ok){
        const activos=  res.lista.filter((x:any)=>x.estadoPermiso==1);
      const uniqueArray1 = activos.filter((x: Permiso, index: number, self: Permiso[]) =>
      index === self.findIndex((t: Permiso) => (
          t.idObjetoPadre === x.idObjetoPadre
      ))
       );
       this.datsPermisosPadre = uniqueArray1;
      }

    });
  }

  cargarModulosHijo() {
        const token = localStorage.getItem('token');
    this.decoded = jwtDecode(token!);
    this._permisoService.getPermisoHijo(this.decoded.idRol).subscribe(res => {
      this.datsPermisosHijo = res.lista;

    });
  }


  ngOnInit(): void {
    this.getLocalStorage();
    this.cargarModulosPadre();
    this.cargarModulosHijo();
  }

}
