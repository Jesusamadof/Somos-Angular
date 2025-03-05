import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Hecho } from '../interfaces/hecho';

@Injectable({
  providedIn: 'root'
})
export class HechoService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Hecho"
    }

    getHechoes(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroHecho(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postHecho(Hecho:Hecho): Observable<Hecho>{
      return this.http.post<Hecho>(this.api+this.urlApi,Hecho);
    }

    putHecho(id:number, Hecho:Hecho): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,Hecho);
    }
    putEstadoHecho(id:number, Hecho:Hecho): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,Hecho);
    }

    putEliminarHecho(id:number, Hecho:Hecho): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,Hecho);
    }

}
