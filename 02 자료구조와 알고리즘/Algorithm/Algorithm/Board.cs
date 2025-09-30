using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head; // 처음
        public MyLinkedListNode<T> Tail; // 마지막
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약에 아직 방이 아예 없었다면, 새로 추가한 첫번째 방이 곧 Head이다
            if (Head == null)
                Head = newRoom;

            // 기존의 [마지막 방]과 [새로 추가되는 방]을 연결해준다
            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // 새로 추가되는 방을 [마지막 방]으로 인정한다
            Tail = newRoom;
            Count++;
            return newRoom;
        }

        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째 방의 다음 방]을 [첫번째 방으로] 인정한다
            if (Head == room)
                Head = Head.Next;

            // [기존의 마지막 방의 이전 방]을 [마지막 방으로] 인정한다
            if (Tail == room)
                Tail = Tail.Prev;

            // 내 이전방과 내 이후방을 이어줌
            if(room.Prev != null)
                room.Prev.Next = room.Next;


            if (room.Next != null)
                room.Next.Prev = room.Prev;
        }
    }

    class MyList<T>
    {
        const int DEFAUT_SIZE = 1;
        T[] _data = new T[DEFAUT_SIZE];

        public int Count = 0; // 실제로 사용중인 데이터 개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터 개수


        // O(1)
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아 있는지 확인
            if(Count >= Capacity)
            {
                // 공간을 다시 늘려서 확보 
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = _data[i];
                _data = newArray;
            }
            // 2. 공간에 데이터를 넣어줌
            _data[Count] = item;

        }

        // 인덱서 O(1)
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; } // 문법
        }

        // O(n)
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                _data[i] = _data[i + 1];

            Count--;
        }
    }

    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] _tile; // 배열
        public int _size;

        public enum TileType
        {
            Empty,
            Wall
        }

        public void Initialize(int size)
        {
            _tile = new TileType[size, size];
            _size = size;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x == 0 || x == _size - 1 || y == 0 || y == size - 1)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor= Console.ForegroundColor;

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[i,j]);
                    Console.Write(CIRCLE);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default: return ConsoleColor.Green;
            }
        }
    }
}
