import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

public class DpShortPath {

	public static void main(String[] args) {
		HashMap<String,String> map=new HashMap<String,String>();
		map.put("a", "b,2;h,8;g,1");
		map.put("b", "h,6;c,1");
		map.put("c", "h,5;i,3;j,9;d,2");
		map.put("d", "j,7;e,9");
		map.put("e", "e,0");
		map.put("f", "e,4;j,1;k,1");
		map.put("g", "k,9;h,7");
		map.put("h", "c,5;i,1;g,7;k,2;b,6");
		map.put("i", "c,3;h,1;k,4;j,9");
		map.put("j", "d,7;f,1;e,2;i,9;c,9;k,3");
		map.put("k", "i,4;j,3;f,1;h,2");
		
		loopHashMap(map);
		String key=Collections.min(dic.entrySet(), new Comparator<Map.Entry<String,Integer>>() {
	        @Override
	        public int compare(Entry<String, Integer> o1, Entry<String, Integer> o2) {
	            return o1.getValue().intValue() - o2.getValue().intValue();
	        }})
	        .getKey();
		System.out.println("Final Path:" +key+"  Min Cost:"+dic.get(key));
	}
	
	static int count=0;
	static HashMap<String,Integer> dic=new HashMap<String,Integer>();
	
	private static void loopHashMap(HashMap<String,String> map) {
		String start="a";
		String end="e";
		StringBuffer sb=new StringBuffer();
		sb.append(start);
		int sum=0;
		
		recursionHashMap(start,map,end,sb,sum);
	}
	
	private static void recursionHashMap(String start,HashMap<String,String> map,String end,
			StringBuffer sbNew,int sumNew) {		
		String value=map.get(start);
		String[] arr=value.split(";");		
		
		for(int i=0;i<arr.length;i++) {
			String[] list=arr[i].split(",");
			StringBuffer sb=new StringBuffer();
			sb.append(sbNew.toString());
			int sum=sumNew;
			
			if(!sb.toString().contains(list[0])) {				
				if(list[0].equals(end)) {
					count++;
					sb.append("-"+list[0]);
					sum=sum+Integer.parseInt(list[1]);
					System.out.println("Path:"+count+"  "+sb.toString()+" Sum:"+sum);
					dic.put(sb.toString(),sum);
				}
				else {
					sum=sum+Integer.parseInt(list[1]);
					sb.append("-"+list[0]);
					recursionHashMap(list[0],map,end,sb,sum);
				}
			}	
		}
	}
}
