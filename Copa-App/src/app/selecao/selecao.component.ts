import { Component, OnInit } from '@angular/core';
import { SelecaoService } from '../_services/selecao.service';
import { BsModalService } from 'ngx-bootstrap';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap';
import { Selecao } from '../_models/Selecao';

@Component({
  selector: 'app-selecao',
  templateUrl: './selecao.component.html',
  styleUrls: ['./selecao.component.css']
})
export class SelecaoComponent implements OnInit {

  selecoesFiltradas: Selecao[];
  selecoes: Selecao[];
  selecao: Selecao;
  modoSalvar = 'post';
  bodyDeletarSelecao: string;
  registerForm: FormGroup;
  FiltroLista: string;
  constructor(
      private selecaoService: SelecaoService
    , private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
  ) { }

  ngOnInit() {
    this.validation();
    this.getSelecoes();
  }

  getSelecoes() {
    this.selecaoService.getAllSelecao().subscribe(
      (selecoes: Selecao[]) => {
        this.selecoes = selecoes;
        this.selecoesFiltradas = selecoes;
        console.log(selecoes);
      },
      error => { console.log(error); }
      );
    }

    validation() {
      this.registerForm = this.fb.group({
        pais: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        grupo: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(1)]]
      });
    }

    editarSelecao(selecao: Selecao, template: any) {
      this.modoSalvar = 'put';
      this.openModal(template);
      this.selecao = selecao;
      this.registerForm.patchValue(this.selecao);
    }

    novaSelecao(template: any) {
      this.modoSalvar = 'post';
      this.openModal(template);
    }

    openModal(template: any) {
      this.registerForm.reset();
      template.show();
    }

    get filtroLista(): string {
      return this.FiltroLista;
    }

    set filtroLista(value: string) {
      this.FiltroLista = value;
      this.selecoesFiltradas = this.filtroLista.length ? this.filtrarSelecoes(this.filtroLista) : this.selecoes;
    }

    filtrarSelecoes(filtrarPor: string): Selecao[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.selecoes.filter(
        selecao => selecao.pais.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        );
      }

    salvarAlteracao(template: any) {
      if (this.registerForm.valid) {
        if (this.modoSalvar === 'post') {
          this.selecao = Object.assign({}, this.registerForm.value);
          this.selecaoService.postSelecao(this.selecao).subscribe(
            (novaSelecao: Selecao) => {
              console.log(novaSelecao);
              template.hide();
              this.getSelecoes();
            }, error => {
              console.log(error);
            }
          );
        } else {
          this.selecao = Object.assign({id: this.selecao.id}, this.registerForm.value);
          this.selecaoService.putSelecao(this.selecao).subscribe(
            (novaSelecao: Selecao) => {
              template.hide();
              this.getSelecoes();
            }, error => {
              console.log(error);
            }
          );
        }
      }
    }

    excluirSelecao(selecao: Selecao, template: any) {
      this.openModal(template);
      this.selecao = selecao;
      this.bodyDeletarSelecao = `Tem certeza que deseja excluir a Seleção: ${selecao.pais}.`;
    }

    confirmeDelete(template: any) {
      this.selecaoService.deleteSelecao(this.selecao.id).subscribe(
        () => {
            template.hide();
            this.getSelecoes();
          }, error => {
            console.log(error);
          }
      );
    }

}
