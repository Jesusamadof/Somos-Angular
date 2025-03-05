import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endpoints } from '../environment/endpoints';
import { OrientacionSexual } from '../interfaces/orientacion-sexual';

@Injectable({
  providedIn: 'root'
})
export class OrientacionSexualService {
  api!:string;
  urlApi!:string;

  constructor(private http:HttpClient) { 
    this.api=Endpoints.urlApi;
    this.urlApi="/api/OrientacionSexual"
  }

  getOrientacion():Observable<any>{
    return this.http.get<any>(this.api+this.urlApi);
  }

  getFiltroOrientacion(id:number):Observable<any>{
    return this.http.get<any>(this.api+this.urlApi+`/${id}`);
  }

  postOrientacion(lista:OrientacionSexual):Observable<OrientacionSexual[]>{
    return this.http.post<OrientacionSexual[]>(this.api+this.urlApi,lista);
  }
  
  putOrientacion(id:number,lista:OrientacionSexual):Observable<void>{
    return this.http.put<void>(this.api+this.urlApi+`/${id}`,lista);
  }
  
  putEstado(id:number,lista:OrientacionSexual):Observable<void>{
    return this.http.put<void>(this.api+this.urlApi+`/actualizarEstado/${id}`,lista);
  }
  putEstadoEliminacion(id:number,lista:OrientacionSexual):Observable<void>{
    return this.http.put<void>(this.api+this.urlApi+`/actualizarEstadoEliminacion/${id}`,lista);
  }
  
}
