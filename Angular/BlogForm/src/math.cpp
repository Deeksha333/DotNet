#include<iostream>
using namespace std;
class rectangle 
{
   private:
   int width,height;
   public:
   void setdimenstions(int w,int h)
   {
    width = w;
    height = h;
      
   }
   int getarea()
   {
    return width * height;
   }
};
int main()
{
    rectangle rect;
    rect.setdimenstions(5,10);
    int area = rect.getarea();
    cout<<"area of rectengle is : "<<area<<endl;
    return 0;
}