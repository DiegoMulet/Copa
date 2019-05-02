import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Selecao } from '../_models/Selecao';

@Injectable({
  providedIn: 'root'
})
export class SelecaoService {

baseURL = 'http://localhost:5000/api/selecao';

constructor(private http: HttpClient) { }

getAllSelecao(): Observable<Selecao[]> {
  return this.http.get<Selecao[]>(this.baseURL);
}

getSelecaoByID(id: number): Observable<Selecao> {
  return this.http.get<Selecao>(`${this.baseURL}/${id}`);
}

postSelecao(selecao: Selecao) {
  return this.http.post(this.baseURL, selecao);
}

putSelecao(selecao: Selecao) {
 return this.http.put(`${this.baseURL}/${selecao.id}`, selecao);
}

deleteSelecao(id: number) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
