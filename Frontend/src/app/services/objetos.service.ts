import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Objeto } from '../interfaces/objeto';

@Injectable({
  providedIn: 'root'
})
export class ObjetosService {
  api:string;
  urlApi:string;

  constructor(
    private http:HttpClient
  ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/objetos"
  }

  getObjeto():Observable<any>{
    return this.http.get(this.api+this.urlApi);
  }

  getFiltroObjeto(id:number):Observable<any>{
    return this.http.get(this.api+this.urlApi+`/${id}`);
  }

  postObjeto(objeto:Objeto):Observable<Objeto>{
    return this.http.post<Objeto>(this.api+this.urlApi,objeto);
  }

  putObjeto(id:number, objeto:Objeto):Observable<void>{
   return this.http.put<void>(this.api+this.urlApi+`/${id}`,objeto);
  }

  putEstadoObjeto(id:number, objeto:Objeto):Observable<void>{
    return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,objeto);
   }

   putEliminarObjeto(id:number, objeto:Objeto):Observable<void>{
    return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,objeto);
   }


}
