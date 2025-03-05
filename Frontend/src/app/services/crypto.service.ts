import { Injectable } from '@angular/core';

import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class CryptoService {
  private secretKey = 'miClaveSecreta123';

  encrypt(data: string): string {
    const encryptedData = CryptoJS.AES.encrypt(data, this.secretKey).toString();
    return encodeURIComponent(encryptedData);
  }

  decrypt(data: string): string {
    const decryptedData = CryptoJS.AES.decrypt(decodeURIComponent(data), this.secretKey);
    return decryptedData.toString(CryptoJS.enc.Utf8);
  }

  constructor() { }
}
