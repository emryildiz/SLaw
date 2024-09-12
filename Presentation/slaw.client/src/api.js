import axios from "axios"

export const getPracticeAreas = async () => {
    const { data } = await axios.get(`${process.env.REACT_APP_BASE_ENDPOINT}/PracticeAreas/GetAll`)

    return data
}

export const getPracticeAreaById = async (id) => {
    const url = `${process.env.REACT_APP_BASE_ENDPOINT}/PracticeAreas/GetById?Id=${id}`
    const { data } = await axios.get(url)

    return data
}

export const getAboutUs = async() => {
    const url = `${process.env.REACT_APP_BASE_ENDPOINT}/AboutUs/Get`
    console.log(url)
    const { data } = await axios.get(url)

    return data
}

export const getLawyers = async() =>{
    const url = `${process.env.REACT_APP_BASE_ENDPOINT}/Lawyers/GetAll`
    const { data } = await axios.get(url)

    return data
}

export const postContactForm = async(item) =>{
    const url = `${process.env.REACT_APP_BASE_ENDPOINT}/ContactForms/Create`
    
    const {data} = await axios.post(url, {
        fullName: item.fullName,
        email: item.email,
        phone: item.phone,
        message: item.message
    });

    return data;
}