import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Permiso } from '../interfaces/permiso';

@Injectable({
  providedIn: 'root'
})
export class PermisosService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Permisos"
    }

    getPermisos(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroPermiso(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postPermiso(Permiso:Permiso): Observable<Permiso>{
      return this.http.post<Permiso>(this.api+this.urlApi,Permiso);
    }

    putPermiso(id:number, Permiso:Permiso): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Permiso);
    }
    putEstadoPermiso(id:number, Permiso:Permiso): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Permiso);
    }

    putEliminarPermiso(id:number, Permiso:Permiso): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Permiso);
    }

    getPermisoPadres(idRol:number): Observable<any>{
     return this.http.get<any>(this.api+this.urlApi+`/permisosPadres/${idRol}`);
    }
    getPermisoHijo(idRol:number): Observable<any>{
      return this.http.get<any>(this.api+this.urlApi+`/permisosHijos/${idRol}`);
     }
}
