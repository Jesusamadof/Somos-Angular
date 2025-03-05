import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { TipoRelacion } from '../interfaces/tipo-relacion';

@Injectable({
  providedIn: 'root'
})
export class TipoRelacionService {


 
  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/TipoRelacion"
    }

    getTipoRelacion(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroTipoRelacion(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postTipoRelacion(TipoRelacion:TipoRelacion): Observable<TipoRelacion>{
      return this.http.post<TipoRelacion>(this.api+this.urlApi,TipoRelacion);
    }

    putTipoRelacion(id:number, TipoRelacion:TipoRelacion): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,TipoRelacion);
    }
    putEstadoTipoRelacion(id:number, TipoRelacion:TipoRelacion): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,TipoRelacion);
    }

    putEliminarTipoRelacion(id:number, TipoRelacion:TipoRelacion): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,TipoRelacion);
    }
}
