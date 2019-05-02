import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Chave } from '../_models/Chave';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChaveService {

  baseURL = 'http://localhost:5000/api/chave';
constructor(private http: HttpClient) { }

getAllChave(): Observable<Chave[]> {
  return this.http.get<Chave[]>(this.baseURL);
}

getChaveByID(id: number): Observable<Chave> {
  return this.http.get<Chave>(`${this.baseURL}/${id}`);
}

postChave(chave: Chave) {
  return this.http.post(this.baseURL, chave);
}

putChave(chave: Chave) {
 return this.http.put(`${this.baseURL}/${chave.id}`, chave);
}

deleteChave(id: number) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
