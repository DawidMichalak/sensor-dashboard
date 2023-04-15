import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadingsMenuComponent } from './readings-menu.component';

describe('ReadingsMenuComponent', () => {
  let component: ReadingsMenuComponent;
  let fixture: ComponentFixture<ReadingsMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReadingsMenuComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReadingsMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
