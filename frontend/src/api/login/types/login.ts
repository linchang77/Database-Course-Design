export interface LoginRequestData {
  username: string
  password: string
}
export interface RegisterRequestData {
  username: string
  password: string
}
export type LoginCodeResponseData = ApiResponseData<string>

export type LoginResponseData = ApiResponseData<{ token: string }>

export type RegisterResponseData = ApiResponseData<{ token: string }>

export type UserInfoResponseData = ApiResponseData<{ username: string; roles: string[] }>
