import { HttpClient } from '@angular/common/http';
import { inject, Service } from '@angular/core';
import { LoginDetails } from '../Models/auth-model';
import { Observable } from 'rxjs';
import { APIResponse } from '../Models/response-model';
import { User } from '../Models/user-model';

@Service()
export class AuthService {

  private http = inject(HttpClient)

  login(request: LoginDetails): Observable<APIResponse<User>> {
    return this.http.post<APIResponse<User>>("url", request);
  }
}

