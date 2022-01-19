import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inspectionApiUrl = "http://localhost:5190/api";

  constructor(private http:HttpClient) { }

  getInspectionList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApiUrl + '/inspectionModels');
  }

  addInspection(data:any){
    return this.http.post(this.inspectionApiUrl + '/inspectionModels', data );
  }

  updateInspection(id:number|string, data:any) {
    return this.http.put(this.inspectionApiUrl + `/inspectionModels/${id}`, data);
  }

  deleteInspection(id:number|string){
    return this.http.delete(this.inspectionApiUrl + `/inspectionModels/${id}`);
  }

  // InspectionTypes
  getInspectionTypesList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApiUrl + '/inspectionTypeModels');
  }

  addInspectionTypes(data:any){
    return this.http.post(this.inspectionApiUrl + '/inspectionTypeModels', data );
  }

  updateInspectionTypes(id:number|string, data:any) {
    return this.http.put(this.inspectionApiUrl + `/inspectionTypeModels/${id}`, data);
  }

  deleteInspectionTypes(id:number|string){
    return this.http.delete(this.inspectionApiUrl + `/inspectionTypeModels/${id}`);
  }

  //Statuses
  getStatusList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApiUrl + '/statusModels');
  }

  addStatus(data:any){
    return this.http.post(this.inspectionApiUrl + '/statusModels', data );
  }

  updateStatus(id:number|string, data:any) {
    return this.http.put(this.inspectionApiUrl + `/statusModels/${id}`, data);
  }

  deleteStatus(id:number|string){
    return this.http.delete(this.inspectionApiUrl + `/statusModels/${id}`);
  }
}
