import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { GeneradorHecho } from '../interfaces/generador-hecho';

@Injectable({
  providedIn: 'root'
})
export class GeneradorHechoService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/GeneradorHecho"
    }

    getGeneradorHechos(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroGeneradorHecho(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postGeneradorHecho(GeneradorHecho:GeneradorHecho): Observable<GeneradorHecho>{
      return this.http.post<GeneradorHecho>(this.api+this.urlApi,GeneradorHecho);
    }

    putGeneradorHecho(id:number, GeneradorHecho:GeneradorHecho): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,GeneradorHecho);
    }
    putEstadoGeneradorHecho(id:number, GeneradorHecho:GeneradorHecho): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,GeneradorHecho);
    }

    putEliminarGeneradorHecho(id:number, GeneradorHecho:GeneradorHecho): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,GeneradorHecho);
    }
}
