import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Rol } from '../interfaces/rol';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Roles"
    }

    getRoles(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroRol(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postRol(rol:Rol): Observable<Rol>{
      return this.http.post<Rol>(this.api+this.urlApi,rol);
    }

    putRol(id:number, rol:Rol): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,rol);
    }
    putEstadoRol(id:number, rol:Rol): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,rol);
    }

    putEliminarRol(id:number, rol:Rol): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,rol);
    }


}
