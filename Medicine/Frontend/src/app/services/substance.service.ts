import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubstanceService {

  apiUrl = 'https://localhost:7076';

  constructor(private http: HttpClient){}

  getAllSubstances(): Observable<any>{
    return this.http.get(`${this.apiUrl}/substances`)
  }

}
