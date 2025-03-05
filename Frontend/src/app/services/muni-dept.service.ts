import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endpoints } from '../environment/endpoints';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MuniDeptService {

  api:string;
  urlApi:string;

  constructor( private http:HttpClient) {
    this.api=Endpoints.urlApi;
    this.urlApi="/api/Muni_Dept"
  }

  getDepartamentos():Observable<any>{
    return this.http.get<any>(this.api+this.urlApi)
  }

  getMunicipios(idDepartamento:any):Observable<any>{
    return this.http.get<any>(this.api+this.urlApi+`/${idDepartamento}`);
  }


}
