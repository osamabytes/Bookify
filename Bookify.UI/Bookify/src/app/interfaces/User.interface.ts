export interface User{
    id: string,
    firstname: string,
    lastname: string,
    age: number,
    email: string,
    password: string,
    confirmpassword: string,
    addressline1: string,
    addressline2: string,
    state: string,
    city: string,
    country: string,
    zipcode: string,
    cardowner: string,
    cardnumber: string,
    cvv: number,
    expiration: string | undefined
}