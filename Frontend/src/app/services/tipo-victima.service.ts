import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { TipoVictima } from '../interfaces/tipo-victima';

@Injectable({
  providedIn: 'root'
})
export class TipoVictimaService {

  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/TipoVictima"
    }

    getTipoVictimaes(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroTipoVictima(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postTipoVictima(TipoVictima:TipoVictima): Observable<TipoVictima>{
      return this.http.post<TipoVictima>(this.api+this.urlApi,TipoVictima);
    }

    putTipoVictima(id:number, TipoVictima:TipoVictima): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,TipoVictima);
    }
    putEstadoTipoVictima(id:number, TipoVictima:TipoVictima): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,TipoVictima);
    }

    putEliminarTipoVictima(id:number, TipoVictima:TipoVictima): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,TipoVictima);
    }

}
