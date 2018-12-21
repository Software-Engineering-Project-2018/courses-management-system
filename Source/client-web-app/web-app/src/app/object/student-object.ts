import { UserObject } from './user-object';

export class StudentObject extends UserObject {
    IdentificationCode: string; // string of student Id
    TotalTutition: number;
    TotalinDebt: number;
}
