
package desktop.development.ProjectEuler;

class ProjectEuler {
    public static void main(String args[]) {
        System.out.println("Hello World!");
        QuickStart qs = new QuickStart();
        System.out.println(qs.SumOfDigits(qs.CalculatePower("2",1000)));
    }

    public String CalculatePower(String num, int power) {

        int carry = 0;
        StringBuffer sb = new StringBuffer(num);
        StringBuffer sbn = new StringBuffer(sb.length() + 1);
        int counter = 1;
        while(counter < power) {
            int len = sb.length();
            for(int idx = len; idx > 0; --idx) {
                int a = Integer.parseInt(String.valueOf(sb.charAt((idx -1))));
                a *= 2;
                a += carry;
                if(a >= 10) {
                    carry = 1;
                    a -= 10;
                } else {
                    carry = 0;
                }
                sbn.append(a);
                
            }
            if(carry == 1) {
                sbn.append("1");
                carry = 0;
            }
            sbn.reverse();
            sb = sbn;
            sbn = new StringBuffer();
            counter++;
        }
        return sb.toString();
    }

    public long SumOfDigits(String num) {

        long sum = 0;
        System.out.println(num);
        char[] digits = num.toCharArray();

        for(int idx = 0; idx < digits.length; ++idx) {
            sum += Integer.parseInt(String.valueOf(digits[idx]));
        }

        return sum;
    }
}