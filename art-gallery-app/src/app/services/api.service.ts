import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private http = inject(HttpClient);

  constructor() {}

  getArtists(){
    this.http.get<any>('https://localhost:44366/api/Artists').subscribe(res => {
      console.log(res);
      return res;
    })
  }


}
