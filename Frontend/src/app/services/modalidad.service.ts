import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Modalidad } from '../interfaces/modalidad';

@Injectable({
  providedIn: 'root'
})
export class ModalidadService {

  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Modalidad"
    }

    getModalidades(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroModalidad(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postModalidad(Modalidad:Modalidad): Observable<Modalidad>{
      return this.http.post<Modalidad>(this.api+this.urlApi,Modalidad);
    }

    putModalidad(id:number, Modalidad:Modalidad): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Modalidad);
    }
    putEstadoModalidad(id:number, Modalidad:Modalidad): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Modalidad);
    }

    putEliminarModalidad(id:number, Modalidad:Modalidad): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Modalidad);
    }



}
