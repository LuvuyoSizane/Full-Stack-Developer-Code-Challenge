import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { User } from './classes/user';

@Injectable({
  providedIn: 'root'
})
export class ServeService {

  private apiUrl = 'http://localhost:5169/api/User';

  constructor(private http: HttpClient) { }

  // Register user method
  registerUser(user: User): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}register`, user); // Assuming POST method for registration
  }

  loginUser(credentials: { Email: string, Password: string }): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, credentials, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).pipe(
      catchError((error) => {
        console.error('Login error:', error);
        return throwError('Invalid credentials or server error.');
      })
    );
  }
}
