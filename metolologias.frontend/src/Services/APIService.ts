import axios, { AxiosInstance } from "axios";
class APIServiceClass {

    private url: string = (process.env.NODE_ENV === 'development') ? "https://localhost:7116/api" : "/api";
    private instance = axios.create();

    constructor() {

        this.instance.interceptors.response.use(function (response) {
            return response;
        }, function (error) {
            return Promise.reject(error);
        });

    }

    GetURL(): string {
        return this.url;
    }

    Axios(): AxiosInstance {
        return this.instance;
    }

}

export const APIService = new APIServiceClass();