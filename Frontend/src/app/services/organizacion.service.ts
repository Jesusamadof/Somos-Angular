import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endpoints } from '../environment/endpoints';
import { HttpClient } from '@angular/common/http';
import { Organizacion } from '../interfaces/organizacion';

@Injectable({
  providedIn: 'root'
})
export class OrganizacionService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Organizaciones"
    }

    getOrganizaciones(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroOrganizacion(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postOrganizacion(Organizacion:Organizacion): Observable<Organizacion>{
      return this.http.post<Organizacion>(this.api+this.urlApi,Organizacion);
    }

    putOrganizacion(id:number, Organizacion:Organizacion): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Organizacion);
    }
    putEstadoOrganizacion(id:number, Organizacion:Organizacion): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Organizacion);
    }

    putEliminarOrganizacion(id:number, Organizacion:Organizacion): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Organizacion);
    }
}
