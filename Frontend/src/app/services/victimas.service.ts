import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';
import { Victima } from '../interfaces/victima';

@Injectable({
  providedIn: 'root'
})
export class VictimasService {


  api!:string;
  urlApi!:string;

  constructor(
    private http:HttpClient
   ) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Victima"
    }

    getVictimaes(): Observable<any>{
      return this.http.get(this.api+this.urlApi);
    }

    getFiltroVictima(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/${id}`);
    }

    postVictima(victima:Victima): Observable<Victima>{
      return this.http.post<Victima>(this.api+this.urlApi,victima);
    }

    putVictima(id:number, victima:Victima): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/${id}`,victima);
    }
    putEstadoVictima(id:number, victima:Victima): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,victima);
    }

    putEliminarVictima(id:number, victima:Victima): Observable<void>{
      return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,victima);
    }

    getCargarDependientes(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/cargarDependientes/${id}`);
    }
    getCargarOrganizaciones(id:number): Observable<any>{
      return this.http.get(this.api+this.urlApi+`/cargarOrganizaciones/${id}`);
    }

    eliminarOrganizaciones(id:number): Observable<void>{
      return this.http.delete<void>(this.api+this.urlApi+`/eliminarOrganizacion/${id}`);
    }

    eliminarDependencias(id:number): Observable<void>{
      return this.http.delete<void>(this.api+this.urlApi+`/eliminarDependiente/${id}`);
    }

}
