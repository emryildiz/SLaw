import { getAboutUs } from "../../api"
import styles from "./styles.module.css"
import { useQuery } from "@tanstack/react-query";
import Loading from "../../components/Loading";

function AboutUs() {

  const query = useQuery({queryKey: ["aboutUs"], queryFn: getAboutUs})

  if(query.isLoading){
    return <div><Loading />.</div>
  }

  const aboutUs = query.data.data;

  return (
    <div className={styles.aboutUs}>
        <div className={styles.title}>
            <h1>HAKKIMIZDA</h1>
        </div>
        
        <div className={styles.content}>
            <div>
                <img src="/assets/logo/ses.png"></img>
            </div>
                <p>{aboutUs.description}</p>
            </div>
    </div>
  )
}

export default AboutUs