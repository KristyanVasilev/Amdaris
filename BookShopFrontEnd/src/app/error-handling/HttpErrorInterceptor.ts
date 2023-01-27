import { HttpErrorResponse, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class HttpErrorInterceptor {

  constructor(private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 400) {
            console.log("Bad Request!", error.message)
          }
          else if (error.status === 404) {
            console.log("Not Found!", error.message)
          }
          else if (error.status === 500) {
            console.log("Iternal error!", error.message)
            //redirect to smth went wrong
          }
          else if (error.status === 401) {
            console.log("Iternal error!", error.message)
            this.router.navigate(['home'])
          }
          else if (error.status === 403) {
            console.log("Iternal error!", error.message)
            window.alert('You are unauthorize!')
            this.router.navigate(['home'])
          }
          return throwError(error);
        })
      )
  }
}