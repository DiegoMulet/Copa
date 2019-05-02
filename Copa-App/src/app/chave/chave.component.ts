import { Component, OnInit } from '@angular/core';
import { ChaveService } from '../_services/chave.service';
import { BsModalService } from 'ngx-bootstrap';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap';
import { Chave } from '../_models/Chave';

@Component({
  selector: 'app-chave',
  templateUrl: './chave.component.html',
  styleUrls: ['./chave.component.css']
})
export class ChaveComponent implements OnInit {
    chavesFiltradas: Chave[];
    chaves: Chave[];
    chave: Chave;
    modoSalvar = 'post';
    bodyDeletarChave: string;
    registerForm: FormGroup;
    FiltroLista: string;

  constructor(
      private chaveService: ChaveService
    , private modalService: BsModalService
    , private fb: FormBuilder
    , private localeService: BsLocaleService
  ) { }

  ngOnInit() {
    this.validation();
    this.getChaves();
  }

  getChaves() {
    this.chaveService.getAllChave().subscribe(
      (chaves: Chave[]) => {
        this.chaves = chaves;
        this.chavesFiltradas = chaves;
        console.log(chaves);
      },
      error => { console.log(error); }
      );
    }

    validation() {
      this.registerForm = this.fb.group({
        selecao1Id: ['', [Validators.required]],
        selecao2Id: ['', [Validators.required]],
        dataConfronto: ['', Validators.required],
        qtdGols1: ['', []],
        qtdGols2: ['', []]
      });

    }

    editarChave(chave: Chave, template: any) {
      this.modoSalvar = 'put';
      this.openModal(template);
      this.chave = chave;
      this.registerForm.patchValue(this.chave);
    }

    novaChave(template: any) {
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
      this.chavesFiltradas = this.filtroLista.length ? this.filtrarChaves(this.filtroLista) : this.chaves;
    }

    filtrarChaves(filtrarPor: string): Chave[] {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.chaves.filter(
        chave => chave.dataConfronto.toString().indexOf(filtrarPor) !== -1
        );
      }

    salvarAlteracao(template: any) {
      if (this.registerForm.valid) {
        if (this.modoSalvar === 'post') {
          this.chave = Object.assign({}, this.registerForm.value);
          this.chaveService.postChave(this.chave).subscribe(
            (novaChave: Chave) => {
              console.log(novaChave);
              template.hide();
              this.getChaves();
            }, error => {
              console.log(error);
            }
          );
        } else {
          this.chave = Object.assign({id: this.chave.id}, this.registerForm.value);
          this.chaveService.putChave(this.chave).subscribe(
            (novaChave: Chave) => {
              template.hide();
              this.getChaves();
            }, error => {
              console.log(error);
            }
          );
        }
      }
    }

    excluirChave(chave: Chave, template: any) {
      this.openModal(template);
      this.chave = chave;
      this.bodyDeletarChave = `Tem certeza que deseja excluir a Chave dos países: ${chave.selecao1Id}, ${chave.selecao2Id}?`;
    }

    confirmeDelete(template: any) {
      this.chaveService.deleteChave(this.chave.id).subscribe(
        () => {
            template.hide();
            this.getChaves();
          }, error => {
            console.log(error);
          }
      );
    }

}
