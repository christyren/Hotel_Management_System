import { Injectable } from '@angular/core';
import { HttpClient,HttpErrorResponse,HttpHeaders,HttpParams } from '@angular/common/http';
import { Observable,throwError } from 'rxjs';
import { map,catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ObserveOnOperator } from 'rxjs/internal/operators/observeOn';


@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private headers:HttpHeaders;

  constructor(protected http:HttpClient) {
    this.headers=new HttpHeaders();
    this.headers.append('Content-Type','application/json');
  }
  getAll(path:string,id?:number):Observable<any>{
    let getUrl:string;
    if (id) {
      getUrl = `${environment.apiUrl}${path}` + '/' + id;
    } else {
      getUrl = `${environment.apiUrl}${path}`;
    }
    return this.http.get(getUrl).pipe(map((resp)=>resp as any[]));
  }
  getOne(path: string,id?:number):Observable<any>{
    let getUrl:string;
    if (id) {
      getUrl = `${environment.apiUrl}${path}` + '/' + id;
    } else {
      getUrl = `${environment.apiUrl}${path}`;
    }
    return this.http.get(getUrl).pipe(map((resp)=>resp as any));
    }

    // getOne(path: string, id?: number, queryParams?: Map<any, any>): Observable<any> {
    //   let getUrl: string;
    //   if (id) {
    //     getUrl = `${environment.apiUrl}${path}` + '/' + id;
    //   } else {
    //     getUrl = `${environment.apiUrl}${path}`;
    //   }
  
    //   let params = new HttpParams();
    //   if (queryParams) {
    //     queryParams.forEach((value: string, key: string) => {
    //       params = params.append(key, value);
    //     });
    //   }
  
    //   return this.http.get(getUrl, { params }).pipe(
    //     map(resp => resp as any),
    //     catchError(this.handleError)
    //   );
    // }

    
  create(path: string, resource:any): Observable<any> {
    return this.http
      .post(`${environment.apiUrl}${path}`, resource, { headers: this.headers })
      .pipe(
        map(response => response)       
      );
  }

  update(path: string, resource:any): Observable<any> {
    return this.http
      .put(
        `${environment.apiUrl}${path}`  + resource.id,resource
        // JSON.stringify({ isRead: true })
      )
      .pipe(
        map(response => response))
      ;
  }

  delete(path: string): Observable<any> {
    return this.http.delete(`${environment.apiUrl}${path}`, { headers: this.headers })
    .pipe(map(response => response));
  } 

}
