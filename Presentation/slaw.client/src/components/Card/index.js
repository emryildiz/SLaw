import { Box } from "@chakra-ui/react"
import styles from "./styles.module.css"
import { Link } from "react-router-dom"

function Card({item}) {
  console.log(item)
  return (
    <div className={styles.card}>
        <Box w="100%" h="250px"><Link to={`/practice-area/${item.id}`}><img width={"100%"} height={"100%"} borderRadius={"5px"} src={item.image}></img></Link></Box>
        <Box w="100%" h="50px" display={"flex"} alignItems={"center"}><Link to={`/practice-area/${item.id}`}  className={styles.title}>{item.name}</Link></Box>
        <Box w="100%" h="90px" overflow={"hidden"} fontSize={"1.1rem"} fontFamily={"monaco,Consolas,Lucida Console,monospace; "} textOverflow={"ellipsis"}>
            <p className={styles.description}>{item.description}</p>
            </Box>
            <Box w="100%" h="10px" display={"flex"} alignItems={"center"} marginTop={"1px"}><Link to={`/practice-area/${item.id}`} className={styles.readMore}>Devamını Oku</Link></Box>
    </div>
  )
}

export default Card