import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class DecodedService {

  decodedToken: any;
  constructor() { }
   public decodedTokenIdUsuario() {
     const token = localStorage.getItem('token');
    const decoded= this.decodedToken = jwtDecode(token!);

     return decoded.idUsuario;
   }


  public decodedTokenData() {
    const token = localStorage.getItem('token');
    const decoded = this.decodedToken = jwtDecode(token!);
    return decoded;
  }

  public decodedTokenCorreo(token:string) {
    const decoded = this.decodedToken = jwtDecode(token);
    return decoded;
  }

}
