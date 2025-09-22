import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {  

  apiUrl = 'https://localhost:7076';

  constructor(private http: HttpClient){}

  getAllMedicines(data: any): Observable<any>{
    const params = {
      tradename: data.tradename,
      currentpage: data.currentpage,
      limit: data.limit
    }
    return this.http.get(`${this.apiUrl}/medicines`, {params} )
  }

  getAllDoses(): Observable<any>{
    return this.http.get(`${this.apiUrl}/doses`)
  }

  getAllManufacturers(): Observable<any>{
    
    return this.http.get(`${this.apiUrl}/manufacturers`)
  }

  getAllMedForms(): Observable<any>{    
    return this.http.get(`${this.apiUrl}/medforms`)
  }

  onRegister(obj: any): Observable<any>{
    return this.http.post(`${this.apiUrl}/medicines`, obj)
  }

  onUpdate(obj: any): Observable<any>{ 
    return this.http.put(`${this.apiUrl}/medicines`, obj)
  }

  getMedicineById(id: any): Observable<any>{    
    return this.http.get(`${this.apiUrl}/medicines/${id}`)
  }

  deleteMedicine(id: any): Observable<any>{
    return this.http.delete(`${this.apiUrl}/medicines/${id}`)
  }

  onSearch(data: any): Observable<any>{
    return this.http.get(`${this.apiUrl}/medicines`, {params: data})
  }

}
