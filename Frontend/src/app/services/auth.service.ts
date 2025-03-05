import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Endpoints } from '../environment/endpoints';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  api:string;
  apiUrl:string;

  constructor(private http:HttpClient) {
    this.api=Endpoints.urlApi;
    this.apiUrl="/api/autenticacion_"
   }

  login(credenciales:any): Observable<any>{
    return this.http.post(this.api+this.apiUrl,credenciales)

  }
}
